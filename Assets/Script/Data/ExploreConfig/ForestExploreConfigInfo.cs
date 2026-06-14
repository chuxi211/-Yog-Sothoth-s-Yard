using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ForestExploreConfigInfo", menuName = "ScriptableObjects/ExploreConfig/ForestExploreConfigInfo", order = 1)]
[Serializable]
public class ForestExploreConfigInfo : ScriptableObject
{
    public ExploreRegion ExploreRegion;
    public int ConsumeTimePeriod;
    public ExploreDropConfigTable ExploreDropConfigTable;
}
public enum ExploreRegion
{
    North,
    South,
    East,
    West
}
