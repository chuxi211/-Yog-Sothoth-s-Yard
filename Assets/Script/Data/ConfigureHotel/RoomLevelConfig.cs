using Data.RunningHotel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    namespace ConfigureHotel
    {
        [CreateAssetMenu(fileName = "RoomLevelConfig", menuName = "ConfigureHotel/RoomLevelConfig", order = 1)]
        [Serializable]
        public class RoomLevelConfig: ScriptableObject
        {
            public RoomID ID;
            public RoomType RoomType;
            public int Level;
            public int MaxNPC;
            public int MaxNPCLevel;
            public int PricePerGuest;
            public GameObject Prefab;
            public UpgradeItem[] UpgradeItems;
            public int UpgradeCost;
        }
    }
    public enum RoomType
    {
        GuestRoom,
        Hall,
        StaffRoom,
        Restaurant,
    }
}
[Serializable]
public class UpgradeItem
{
    public ItemConfigureInfo ItemInfo;
    public int Quantity;
}