using Data.ConfigureHotel;
using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabComponentBuilder : IComponentBuilder
{
    public void BuildComponent(RoomRunning roomRunning, RoomLevelConfig levelConfig)
    {
        var prefabcmp = new PrefabComponent(roomRunning.roomActor);
        roomRunning.AddComponent(prefabcmp);
    }
}
