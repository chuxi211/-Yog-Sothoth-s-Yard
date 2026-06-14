using Command.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanButton : MonoBehaviour
{
    private CommandInvoker Invoker;
    public int Cleanliness { get; protected set; }
    public int SanValue { get; protected set; }
    public void Init(CommandInvoker invoker)
    {
        Invoker = invoker;
    }
    public void OnClick()
    {
        Invoker.Execute(new CleanCommand(Cleanliness, SanValue));
        EventBus.Publish(new RequestCleanAnimEvent());
        Debug.Log($"Cleanliness:{Cleanliness},San:{SanValue}");
    }
}
