using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command.Management
{
    public class SetRestaurantMenuCommand : Command
    {
        public List<SellingSlotInfo> slots;
        public SetRestaurantMenuCommand(List<SellingSlotInfo> slots)
        {
            this.slots = slots;
            ConsumeActionPoint = false;
            TargetType = TargetType.Room;
            CommandType = CommandType.SetRestaurantMenu;
        }
    }

}