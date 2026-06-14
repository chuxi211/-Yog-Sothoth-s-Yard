using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomActor:MonoBehaviour
{
    public RoomRunning roomRunning { get; private set; }
    public CollectCoinButton CollectCoinButton { get; private set; }
    public UpgradeClick UpgradeClick { get; private set; }
    public RoomDetailPage DetailPage { get; private set; }
    private void Awake()
    {
        CollectCoinButton = GetComponentInChildren<CollectCoinButton>();
        DetailPage = GetComponentInChildren<RoomDetailPage>();
        UpgradeClick = GetComponentInChildren<UpgradeClick>();
    }
    public void Init(RoomRunning roomRunning)
    {
        this.roomRunning = roomRunning;
    }
}