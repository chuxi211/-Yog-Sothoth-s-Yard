using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSwitchAnimPlayer:AnimationPlayer
{
    [SerializeField] private Animator BGAnimator;
    [SerializeField] private Animator DayIconAnimator;
    [SerializeField] private Animator NightIconAnimator;

    public override Type RequestType =>typeof(RequestDayNightSwitchAnim);
    private void Awake()
    {
        Debug.Log("BGAnim.name:"+BGAnimator.name);
        Debug.Log("DayIconAnim:"+DayIconAnimator.name);
        Debug.Log("NightIconAnimator"+NightIconAnimator.name);
    }
    public override IEnumerator Play(AnimRequest animRequest)
    {
        BGAnimator.Play("FadeIn");
        yield return null;

    }
}