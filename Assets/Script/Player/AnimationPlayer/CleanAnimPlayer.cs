using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanAnimPlayer : AnimationPlayer
{
    [SerializeField] private Animator animator;
    private void Awake()
    {
        Debug.Log($"animator.gameObject has CleanAnimPlayer?:{animator.gameObject.GetComponent<CleanAnimPlayer>()}");
    }
    public override Type RequestType => typeof(RequestCleanAnimEvent);

    public override IEnumerator Play(AnimRequest animRequest)
    {
        animator.SetTrigger("ToClean");
        Debug.Log($"CurrentAnim: Clean");
        yield return null;
    }
    public void TestFun()
    {
        EventBus.Publish(new AnimationEndedEvent());
        Debug.Log("Clean Anim Finished");
    }
}
