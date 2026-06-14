using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIconChanger : MonoBehaviour
{
    public Sprite[] Icons;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void OnEnable()
    {
        EventBus.Subscribe<HotelLevelChangedEvent>(UpdateIcon);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<HotelLevelChangedEvent>(UpdateIcon);
    }
    private void UpdateIcon(HotelLevelChangedEvent e)
    {
        image.sprite = Icons[e.Level];
    }
}
