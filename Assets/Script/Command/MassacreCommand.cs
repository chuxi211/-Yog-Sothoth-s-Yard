using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command.Management
{
    public class MassacreCommand : Command
    {
        public MassacreCommand()
        {
            ConsumeActionPoint = true;
            CommandType = CommandType.Massacre;
            TargetType = TargetType.Hotel;
        }
    }
}