using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command.Management
{
    public class StartForestExploreCommand : Command
    {
        public ExploreRegion Region;
        public StartForestExploreCommand(ExploreRegion region)
        {
            //根据Region和Level唯一确定一个ForestExploreConfigInfo
            Region = region;
            CommandType = CommandType.StartForestExplore;
            TargetType = TargetType.System;
            ConsumeActionPoint = true;
        }
    }
}