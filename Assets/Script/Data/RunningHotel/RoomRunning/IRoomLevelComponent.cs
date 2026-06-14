using Data.ConfigureHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRoomLevelComponent
{
    int Level { get; }
    void ApplyLevel(RoomLevelConfig roomLevelConfig);
    void Upgrade(RoomLevelConfig roomLevelConfig);
}