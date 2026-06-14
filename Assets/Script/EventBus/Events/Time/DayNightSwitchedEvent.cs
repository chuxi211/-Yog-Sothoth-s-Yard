using Data.Time;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSwitchedEvent
{
    public TimePeriod Period;
    public DayNightSwitchedEvent(TimePeriod period)
    {
        Period = period;
    }
}