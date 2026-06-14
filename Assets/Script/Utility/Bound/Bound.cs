using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Bounds",menuName ="ScriptableObjects/Bounds")]
[Serializable]
public class Bound : ScriptableObject
{
    public int FloorIndex;
    public Vector3 MaxBound;
    public Vector3 MinBound;
    public Bounds ToBounds()
    {
        Vector3 center = (MaxBound + MinBound) * 0.5f;
        Vector3 size = MaxBound - MinBound;
        return new Bounds(center, size);
    }
}