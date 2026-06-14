using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartForestExploreButton : MonoBehaviour
{
    private CommandInvoker Invoker;      //Init绑定，见Init的引用
    [SerializeField]
    private ExploreRegion ExploreRegion; //Inspector中绑定
    public void Init(CommandInvoker invoker)
    {
        Invoker = invoker;
    }
    public void OnClick()
    {
        Invoker.Execute(new Command.Management.StartForestExploreCommand(this.ExploreRegion));
    }
}
