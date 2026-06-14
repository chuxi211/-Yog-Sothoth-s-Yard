using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AllCGs", menuName = "ScriptableObjects/AllCGs", order = 1)]
public class AllCGs : ScriptableObject
{
    public List<Sprite> CGs;
}