using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCoin : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        EventBus.Subscribe<CoinBufferChangedEvent>(ShowOrHide);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<CoinBufferChangedEvent>(ShowOrHide);
    }
    private void ShowOrHide(CoinBufferChangedEvent e)
    {
        RoomActor actor;
        if(actor= gameObject.GetComponentInParent<RoomActor>())
        {
            return;
        }
        if (!actor.roomRunning.ID.Equals(e.ID))
        {
            return;
        }
        if(e.Coin > 0)
        {
            ShowIcon();
        }
        else
        {
            HideIcon();
        }
    }
    private void HideIcon()
    {
        SpriteRenderer.enabled = false;
    }
    private void ShowIcon()
    {
        SpriteRenderer.enabled = true;
    }
}
