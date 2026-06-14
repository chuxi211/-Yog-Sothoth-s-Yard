using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Data
{
    namespace Economy
    {
        public class Economy
        {
            public int Coin { get; private set; }
            public int AllCoin { get; private set; }
            public int Soul { get; private set; }
            public int SAN { get; private set; }
            public int Cleanliness { get; private set; }
            public int Evil { get; private set; }
            public Economy()
            {
                Coin = 0;
                AllCoin = 0;
                Soul = 0;
                SAN = 100;
                Cleanliness = 1000;
                Evil = 0;
                EventBus.Publish(new CleanlinessValueChangedEvent(Cleanliness));
                EventBus.Publish(new CoinValueChangedEvent(Coin));
                EventBus.Publish(new EvilValueChangedEvent(Evil));
                EventBus.Publish(new SANValueChangedEvent(SAN));
                EventBus.Publish(new SoulValueChangedEvent(Soul));
            }
            public Economy(int coin,int allcoin, int soul, int sAN, int cleanliness, int evil)
            {
                Coin = coin;
                AllCoin = allcoin;
                Soul = soul;
                SAN = sAN;
                Cleanliness = cleanliness;
                Evil = evil;
            }

            public void ChangeCoin(int amount)
            {
                if (amount > 0) AddAllCoin(amount);
                Coin += amount;
                if (Coin <= 0)
                {
                    Coin = 0;
                }
                Debug.Log($"Current Coin{Coin}");
                EventBus.Publish(new CoinValueChangedEvent(Coin));
            }
            private void AddAllCoin(int amout)
            {
                AllCoin += amout;
            }
            public void ChangeSoul(int amount)
            {
                Soul += amount;
                if (Coin <= 0)
                {
                    Soul = 0;
                }
                Debug.Log($"Current Soul:{Soul}");
            }
            public void ChangeSAN(int amount)
            {
                SAN += amount;
                if (SAN >= 100)
                {
                    SAN = 100;
                }
                if (SAN <= 0)
                {
                    SAN = 0;
                }
                Debug.Log($"Current SAN:{SAN}");
                EventBus.Publish(new SANValueChangedEvent(SAN));
            }
            public void ChangeCleanliness(int amount)
            {
                Cleanliness += amount;
                if (Cleanliness <= 0)
                {
                    Cleanliness = 0;
                }
                if (Cleanliness >= 1000)
                {
                    Cleanliness = 1000;
                }
                Debug.Log($"Current Cleanliness {Cleanliness}");
                EventBus.Publish(new CleanlinessValueChangedEvent(Cleanliness));
            }
        }
    }
}
public class CleanlinessValueChangedEvent
{
    public int value { get; private set; }
    public CleanlinessValueChangedEvent(int value)
    {
        this.value = value;
    }
}
public class CoinValueChangedEvent
{
    public int value { get; private set; }
    public CoinValueChangedEvent(int value)
    {
        this.value = value;
    }
}
public class EvilValueChangedEvent
{
    public int value { get; private set; }
    public EvilValueChangedEvent(int value)
    {
        this.value = value;
    }
}
public class SANValueChangedEvent
{
    public int value { get; private set; }
    public SANValueChangedEvent(int value)
    {
        this.value = value;
    }
}
public class SoulValueChangedEvent
{
    public int value { get; private set; }
    public SoulValueChangedEvent(int value)
    {
        this.value = value;
    }
}