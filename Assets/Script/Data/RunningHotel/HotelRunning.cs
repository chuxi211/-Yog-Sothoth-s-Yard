using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data.RunningHotel
{
    public class HotelRunning
    {
        public int CurrentLevel { get; private set; }
        public int CoinGoal { get; private set; }
        public int CleanlinessGoal { get; private set; }
        public int UnlockedFloor { get; private set; }
        public HotelRunning(HotelLevelConfigTable hotelLevelConfigTable)
        {
            CurrentLevel=hotelLevelConfigTable.Level;
            CoinGoal = hotelLevelConfigTable.AllCoinGoal;
            CleanlinessGoal = hotelLevelConfigTable.CleanlinessGoal;
            UnlockedFloor = hotelLevelConfigTable.UnlockedFloor;
            EventBus.Publish(new HotelLevelChangedEvent(CurrentLevel));
        }
        public void LevelUp(HotelLevelConfigTable newLevel)
        {
            CurrentLevel++;
            CoinGoal = newLevel.AllCoinGoal;
            CleanlinessGoal = newLevel.CleanlinessGoal;
            UnlockedFloor = newLevel.UnlockedFloor;
            EventBus.Publish(new HotelLevelChangedEvent(CurrentLevel));
        }
    }
}