using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command.Management
{
    public class CollectCoinCommand : Command
    {
        public RoomID TargetID { get; private set; }
        public CollectCoinCommand(RoomID ID)
        {
            TargetID = ID;
            CommandType = CommandType.CollectRate;
            TargetType = TargetType.Room;
            ConsumeActionPoint = false;
        }
    }
}