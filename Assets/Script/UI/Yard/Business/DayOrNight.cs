using Data.Time;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayOrNight : MonoBehaviour
{
    public Sprite Day;
    public Sprite Night;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void OnEnable()
    {
        EventBus.Subscribe<DayNightSwitchedEvent>(ChangeSprite);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<DayNightSwitchedEvent>(ChangeSprite);
    }
    public void ChangeSprite(DayNightSwitchedEvent e)
    {
        image.sprite = e.Period == TimePeriod.Day ? Day : Night;
    }
}
