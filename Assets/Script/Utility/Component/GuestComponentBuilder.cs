using Data.ConfigureHotel;
using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestComponentBuilder : IComponentBuilder
{
    public readonly NPCFactory npcFactory;
    public readonly NPCDataBase npcDataBase;
    public GuestComponentBuilder(NPCFactory npcFactory, NPCDataBase npcDataBase)
    {
        this.npcFactory = npcFactory;
        this.npcDataBase = npcDataBase;
    }
    public void BuildComponent(RoomRunning roomRunning,RoomLevelConfig levelConfig)
    {
        var guestComponent = new GuestComponent();
        Debug.Log(nameof(guestComponent)+"was inited");
        guestComponent.BindNPCDataBase(npcDataBase);
        guestComponent.BindNPCFactory(npcFactory);
        guestComponent.ApplyLevel(levelConfig);
        roomRunning.AddComponent(guestComponent);
        guestComponent.BindRoomID(roomRunning.ID);
        Debug.Log("GuestComponent was added to " + roomRunning.ID.Floor.ToString() + "-" + roomRunning.ID.Index.ToString());
    }
}