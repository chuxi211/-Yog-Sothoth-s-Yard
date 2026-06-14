using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonthSwitchedEvent
{
    public int Month { get; private set; }
    public MonthSwitchedEvent(int month)
    {
        Month = month;
    }
}