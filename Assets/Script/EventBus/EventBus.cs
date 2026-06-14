using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    private static Dictionary<Type,Delegate> Events=new();
    public static void Subscribe<T>(Action<T> callback)
    {

        Type type = typeof(T);
        if (!Events.ContainsKey(type))
        {
            Events[type] = null;
        }
        Events[type] = (Action<T>)Events[type] + callback;
    }
    public static void UnSubscribe<T>(Action<T> callback)
    { 
        Type type = typeof(T);
        if (!Events.ContainsKey(type)) { return; }
        Events[type] = (Action<T>)Events[type] - callback;
        if (Events[type] == null)
        {
            Events.Remove(type);
        }
    }
    public static void Publish<T>(T eventData)
    {
        Type type = typeof(T);
        if (Events.TryGetValue(type, out Delegate @delegate))
        {
            Action<T> callback = @delegate as Action<T>;
            Debug.Log($"Try Publish {callback.ToString()}");
            callback?.Invoke(eventData);
        }
    }
    public static void Clear()
    {
        Events.Clear();
    }
}
