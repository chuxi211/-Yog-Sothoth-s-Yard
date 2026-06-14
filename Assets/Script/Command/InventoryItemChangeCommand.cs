using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command.Management
{
    public class InventoryItemChangeCommand : Command
    {
        public ItemRunning Item { get;private set; }
        public int Count { get; private set; }
        public InventoryItemChangeCommand(ItemRunning item, int count)
        {
            Item = item;
            Count = count;
            ConsumeActionPoint = false;
            TargetType = TargetType.System;
            CommandType = CommandType.ChangeItem;
        }
    }
}