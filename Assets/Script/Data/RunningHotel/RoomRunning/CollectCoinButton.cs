using Command.Management;
using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinButton : MonoBehaviour,IRoomClick
{
    private CommandInvoker Invoker;
    private RoomActor RoomActor;
    private void Awake()
    {
        RoomActor = GetComponentInParent<RoomActor>();
    }
    public void Click()
    {
        Invoker.Execute(new CollectCoinCommand(RoomActor.roomRunning.ID));
    }

    public void Init(CommandInvoker invoker)
    {
        Invoker = invoker;
    }
}
