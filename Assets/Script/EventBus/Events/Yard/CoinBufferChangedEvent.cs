using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBufferChangedEvent {
    public RoomID ID;
    public int Coin { get; private set; }
    public CoinBufferChangedEvent(RoomID iD ,int Coin)
    {
        ID = iD;
        this.Coin = Coin;
    }
}