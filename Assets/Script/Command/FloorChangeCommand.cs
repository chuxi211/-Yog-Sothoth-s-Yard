using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command
{
    namespace Management
    {
        public class FloorChangeCommand : Command
        {
            public int FloorIndex { get;private set; }
            public FloorChangeCommand(int floorIndex)
            {
                ConsumeActionPoint = false;
                this.CommandType = CommandType.ChangeScene;
                this.TargetType = TargetType.System;
                FloorIndex = floorIndex;
            }
        }
    }
}
