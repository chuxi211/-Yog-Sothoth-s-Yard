using Command.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeClick : MonoBehaviour, IRoomClick
{
    private RoomActor RoomActor;
    private CommandInvoker Invoker;
    private void Awake()
    {
        RoomActor = GetComponentInParent<RoomActor>();
    }
    public void Click()
    {
        if (RoomActor.roomRunning == null)
        {
            Debug.LogError($"Running is null");
        }
        if (Invoker == null)
        {
            Debug.LogError("Invoker is null");
        }
        Invoker.Execute(new ToUpgradeCommand(RoomActor.roomRunning.ID));
    }
    public void Init(CommandInvoker invoker)
    {
        Invoker = invoker;
        Debug.Log(invoker.ToString()+"in Room has been Inited");
    }
}
