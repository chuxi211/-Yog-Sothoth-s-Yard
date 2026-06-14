using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelLevelChangedEvent
{
    public int Level { get; private set; }
    public HotelLevelChangedEvent(int level)
    {
        Level = level;
    }
}