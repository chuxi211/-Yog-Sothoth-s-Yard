using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateSwitchedEvent 
{
    public int Month { get; private set; }
    public int Week {  get; private set; }
    public int Day {  get; private set; }
    public DateSwitchedEvent(int month,int week,int day)
    {
        Month = month;
        Week = week;
        Day = day;
    }
}
