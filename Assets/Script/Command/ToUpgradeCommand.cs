using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command.Management
{
    public class ToUpgradeCommand : Command
    {
        public RoomID RoomID;
        public ToUpgradeCommand(RoomID RoomID)
        {
            this.RoomID = RoomID;
            ConsumeActionPoint = true;
            CommandType = CommandType.ToUpgrade;
            TargetType = TargetType.Room;
        }
    }
}