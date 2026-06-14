using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationPlayer : MonoBehaviour, IAnimationPlayer
{
    protected AnimationSystem animationSystem;
    public void BindAnimSystem(AnimationSystem animationSystem)
    {
        this.animationSystem = animationSystem;
    }

    public virtual IEnumerator Play(AnimRequest animRequest)
    {
        throw new System.NotImplementedException();
    }
    public abstract Type RequestType
    {
        get;
    }
    public void Registe()
    {
        animationSystem.Register(RequestType, this);
    }
    
}
