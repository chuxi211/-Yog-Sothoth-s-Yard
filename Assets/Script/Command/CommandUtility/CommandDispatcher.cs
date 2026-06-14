using Command.Management;
using Data.Economy;
using Data.RunningHotel;
using RoomState;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommandDispatcher
{
    private RoomManager roomManager;
    private Data.Time.Time GameTime;
    private ForestExploreSystem ForestExploreSystem;
    private Economy economy;
    private Inventory inventory;
    private Crafter crafter;
    public CommandDispatcher(RoomManager roomManager, Data.Time.Time gameTime,
                            ForestExploreSystem forestExploreSystem,Economy economy, 
                            Inventory inventory,Crafter crafter)
    {
        this.roomManager = roomManager;
        GameTime = gameTime;
        this.ForestExploreSystem = forestExploreSystem;
        this.economy = economy;
        this.inventory = inventory;
        this.crafter = crafter;
    }
    public void Dispatche(Command.Management.Command command)
    {
        bool isSuccess=false;
        switch (command.TargetType)
        {
            //暂时先这么用着，之后会重写整个Dispatch
            case Command.Management.TargetType.Room:
                isSuccess= HandleRoomCommand(command);
                break;
            case Command.Management.TargetType.Layer:
                isSuccess = HandleLayerCommand(command);
                break;
            case Command.Management.TargetType.Hotel:
                isSuccess= HandleHotelCommand(command);
                break;
            case Command.Management.TargetType.System:
                isSuccess= HandleSystemCommand(command);
                break;
        }
        if(isSuccess)
        GameTime.AdvanceTime(command.ConsumeActionPoint);
    }
    private bool HandleRoomCommand( Command.Management.Command command)
    {
        switch (command.CommandType)
        {
            case Command.Management.CommandType.CollectRate:
                CollectCoinCommand collectCoinCommand = command as CollectCoinCommand;
                RoomRunning room = roomManager.GetRoom(collectCoinCommand.TargetID);
                var guestcomp=room.GetComponent<GuestComponent>();
                economy.ChangeCoin(guestcomp.TryCollectCoin());
                return true;
            case CommandType.SetRestaurantMenu:
                SetRestaurantMenuCommand setcommand=command as SetRestaurantMenuCommand;
                RoomRunning temproom = roomManager.GetRoom(new Data.RoomID(1, 6));
                var restaurant=temproom.GetComponent<RestaurantComponent>();
                restaurant.SetMenu(setcommand.slots);
                return true;
            case CommandType.ToUpgrade:
                ToUpgradeCommand cmd = command as ToUpgradeCommand;
                Debug.Log("Room to Upgrade");
                RoomRunning room1=roomManager.GetRoom(cmd.RoomID);
                room1.roomStateMachine.ChangeState<LevelEvaluationState>();
                return true;
        }
        return false;
    }
    private bool HandleLayerCommand(Command.Management.Command command) 
    {
        return false;
    }
    private bool HandleHotelCommand(Command.Management.Command command)
    {
        switch (command.CommandType)
        {
            case Command.Management.CommandType.CleanRoom:
                CleanCommand cleanCommand = command as CleanCommand;
                Debug.Log($"CleanCommand is Dispatched:{cleanCommand.Cleanliness}   {cleanCommand.San}");
                economy.ChangeCleanliness(cleanCommand.Cleanliness);
                economy.ChangeSAN(cleanCommand.San);
                return true;
            case Command.Management.CommandType.ChangeCleanliness:
                ChangeCleanlinessCommand changeCleanlinessCommand = command as ChangeCleanlinessCommand;
                economy.ChangeCleanliness(changeCleanlinessCommand.value);
                return true;
            case Command.Management.CommandType.Massacre:
                List<RoomRunning> roomRunnings = roomManager.GetAllRoom();
                economy.ChangeSAN(-10);
                for (int i = 0; i < roomRunnings.Count; i++)
                {
                    var guestcomp=roomRunnings[i]?.GetComponent<GuestComponent>();
                    if (guestcomp != null)
                    {
                        economy.ChangeCoin(guestcomp.GetAllCoin());
                        guestcomp.RemoveAllNPC();
                    }
                }
                return true;
        }
        return false;
    }
    private bool HandleSystemCommand(Command.Management.Command command)
    {
        switch(command.CommandType)
        {
            case Command.Management.CommandType.ChangeScene:
                CameraController cameraController = GameObject.FindObjectOfType<CameraController>();
                List<Bound> boundbuffers = Resources.LoadAll<Bound>("Bounds/").ToList();
                FloorChangeCommand floorChangeCommand = command as FloorChangeCommand;
                foreach(var bound in boundbuffers)
                {
                    if (floorChangeCommand.FloorIndex == bound.FloorIndex)
                    {
                        cameraController.SetBound(bound.ToBounds());
                    }
                }
                return true;
            case CommandType.ChangeItem:
                InventoryItemChangeCommand changeCommand = command as InventoryItemChangeCommand;
                inventory.ChangeItemCount(changeCommand.Item.Item.ID,changeCommand.Count);
                return true;
            case CommandType.StartForestExplore:
                StartForestExploreCommand foresExploreCommand = command as StartForestExploreCommand;
                return  ForestExploreSystem.TryStartExplore(foresExploreCommand.Region);
            case CommandType.Cooking:
                StartCookingCommand StartCookingCommand = command as StartCookingCommand;
                List<ItemRunning> itemRunnings = new();
                foreach (var r in StartCookingCommand.Recipe.RawMaterials)
                {
                    itemRunnings.Add(inventory.GetItem(r.Item.ID));
                }
                crafter.Craft(StartCookingCommand.Recipe);
                return true;
        }
        return false;
    }
}
