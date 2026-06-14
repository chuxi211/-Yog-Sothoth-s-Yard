using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command
{
    namespace Management
    {
        public abstract class Command
        {
            public bool ConsumeActionPoint { get; protected set; }
            public CommandType CommandType { get; protected set; }
            public TargetType TargetType { get; protected set; }
        }
        public enum CommandType 
        { 
            UpgradeRoom,
            ToUpgrade,
            CollectRate,
            ChangeCleanliness,
            CleanRoom,
            ChangeScene,
            ChangeItem,
            Massacre,
            StartForestExplore,
            SetRestaurantMenu,
            Cooking,
        }
        public enum TargetType
        {
            Room,
            Layer,
            Hotel,
            System,
        }
    }
}