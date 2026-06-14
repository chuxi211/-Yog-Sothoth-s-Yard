using Command.Management;
using Data.ConfigureHotel;
using Data.Economy;
using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RoomState
{
    public class LevelEvaluationState : RoomState
    {
        private Dictionary<int,RoomLevelConfig> LevelConfigs=new Dictionary<int,RoomLevelConfig>();
        private RoomLevelConfig NextConfig;
        private List< IRoomLevelComponent> LevelComponents;
        private Inventory Inventory;
        private Economy Economy;
        public LevelEvaluationState(RoomStateMachine roomStateMachine, RoomRunning room,Dictionary<int , RoomLevelConfig> configs
                                    ,Inventory inventory,Economy economy) 
                                    : base(roomStateMachine, room)
        {
            LevelConfigs = configs;
            Inventory = inventory;
            Economy = economy;
        }

        public override void Enter()
        {

            if (CanUpgrade())
            {
                Upgrade();
            }
            else
            {
                Debug.Log("Can not Upgrade");
            }
            roomStateMachine.ChangeState<RunningState>();
        }
        private bool CanUpgrade()
        {
            var components = Room.GetComponents<IRoomLevelComponent>();
            LevelComponents = components;
            foreach (var component in components)
            {
                if (!LevelConfigs.TryGetValue(component.Level + 1, out var config))
                {
                    return false;
                }
                NextConfig = config;
                if (config.UpgradeCost > Economy.Coin)
                {
                    return false;
                }
                foreach (var item in config.UpgradeItems)
                {
                    if (item.Quantity > Inventory.GetItemCount(item.ItemInfo.ID))
                        return false;
                }
            }
            return true;
        }
        private void Upgrade()
        {
            Economy.ChangeCoin(-NextConfig.UpgradeCost);
            foreach(var item in NextConfig.UpgradeItems)
            {
                Inventory.ChangeItemCount(item.ItemInfo.ID, -item.Quantity);
            }
            foreach (var LevelComponent in LevelComponents)
            {
                LevelComponent.Upgrade(NextConfig);
            }
        }
    }
}