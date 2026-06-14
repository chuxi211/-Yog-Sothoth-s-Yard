using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassacreButton : MonoBehaviour
{
    private CommandInvoker Invoker;
    public void Init(CommandInvoker invoker)
    {
        Invoker = invoker;
    }
    public void OnClick()
    {
        Invoker.Execute(new Command.Management.MassacreCommand());
        //EventBus.Publish(new RequestCloseMassacrePanel());
    }
}
