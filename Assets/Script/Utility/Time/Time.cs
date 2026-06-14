using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Data
{
    namespace Time
    {
        public class Time
        {
            public int Month { get; private set; }
            public int Week { get; private set; }
            public int Day { get; private set; }
            public int MaxDayActionPoint { get; private set; }
            public int MaxNightActionPoint { get; private set; }
            public int DayActionPoint { get; private set; }
            public int NightActionPoint { get; private set; }
            public TimePeriod TimePeriod { get; private set; } = TimePeriod.Day;
            public Time()
            {
                Month = 1;
                Week = 1;
                Day = 1;
                MaxDayActionPoint = 1;
                MaxNightActionPoint = 1;
                DayActionPoint = MaxDayActionPoint;
                NightActionPoint = MaxNightActionPoint;
                EventBus.Publish(new ActionPointChangedEvent(DayActionPoint));
                EventBus.Publish(new DateSwitchedEvent(Month,Week,Day));
            }
            public void AdvanceTime(bool isConsumeActionPoint)
            {
                if (!isConsumeActionPoint) return;
                if (TimePeriod == TimePeriod.Day)
                {
                    DayActionPoint--;
                    EventBus.Publish(new ActionPointChangedEvent(DayActionPoint));
                    if (DayActionPoint == 0)
                    {
                        TimePeriod = TimePeriod.Night;
                        EventBus.Publish(new DayNightSwitchedEvent(TimePeriod));
                        Debug.Log($"CurrentPeriod:{TimePeriod}");
                        DayActionPoint = MaxDayActionPoint;//ÖØÖÃ¼ÆÊýÆ÷
                    }
                }
                else
                {
                    NightActionPoint--;
                    EventBus.Publish(new ActionPointChangedEvent(NightActionPoint));
                    if (NightActionPoint == 0)
                    {
                        TimePeriod = TimePeriod.Day;
                        EventBus.Publish(new DayNightSwitchedEvent(TimePeriod));
                        Debug.Log($"CurrentPeriod:{TimePeriod}");
                        NightActionPoint = MaxNightActionPoint;
                        NextDay();
                    }
                }
            }
            private void NextDay()
            {
                Day++;
                if (Day > 7)
                {
                    Day = 1;
                    NextWeek();
                }
                Debug.Log($"CurrentDay:{Day}");
                EventBus.Publish(new DateSwitchedEvent(Month,Week,Day));
            }
            private void NextWeek()
            {
                Week++;
                if (Week > 4)
                {
                    Week = 1;
                    NextMonth();
                }
                Debug.Log($"CurrentWeek:{Week}");
            }
            private void NextMonth()
            {
                Month++;
                EventBus.Publish(new MonthSwitchedEvent(Month));
                Debug.Log($"CurrentMonth:{Month}");
            }
        }
        public enum TimePeriod
        {
            Day,
            Night
        }
    }
}
