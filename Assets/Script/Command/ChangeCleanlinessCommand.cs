using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command.Management
{
    public class ChangeCleanlinessCommand:Command
    {
        public int value { get; private set; }
        public ChangeCleanlinessCommand(int value)
        {
            this.value = value;
            this.ConsumeActionPoint = false;
            this.CommandType = CommandType.ChangeCleanliness;
            this.TargetType = TargetType.Hotel;
            if(value > 0)
            {
                value = 0;
                Debug.LogError($"{nameof(ChangeCleanlinessCommand)}: {value} Can not > 0");
            }
        }
    }
}