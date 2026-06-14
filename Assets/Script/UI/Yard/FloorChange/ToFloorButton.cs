using Command.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFloorButton:MonoBehaviour
{
    [SerializeField] private int Floor;
    private CommandInvoker Invoker;
    public void Init(CommandInvoker commandInvoker)
    {
        this.Invoker = commandInvoker;
    }
    public void OnClick()
    {
        Invoker.Execute(new FloorChangeCommand(Floor));
        EventBus.Publish(new CloseFloorChangePanelEvent());
        EventBus.Publish(new FloorSwitchedEvent(Floor));
    }
}