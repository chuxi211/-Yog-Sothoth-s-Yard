using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSystem:MonoBehaviour
{
    private Dictionary<Type,IAnimationPlayer> Players = new Dictionary<Type,IAnimationPlayer>();
    public void Register(Type Type, IAnimationPlayer player)
    {
        if (Players.ContainsKey(Type))
        {
            Debug.LogError(
                $"Duplicate AnimationPlayer: {Type}"
            );

            return;
        }
        Players[Type] = player;
    }
    public void Play(AnimRequest Type)
    {
        if(Players.TryGetValue(Type.GetType(),out var player))
        {
            StartCoroutine(player.Play(Type));
            Debug.Log("StartPlay ");
        }
        else
        Debug.Log("Not Found This Anim.AnimType:"+Type.GetType());
    }
}
