using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
[CreateAssetMenu(fileName ="Item",menuName ="ItemConfigureInfo/Item")]
public class ItemConfigureInfo : ScriptableObject
{
    public string ID;
    public string Name;
    public string Description;
    public int Level;
    public int Price;
    public Sprite Icon;
    public ItemType Type;
}
public enum ItemType
{
    RawFood,
    SellingFood,
    Building,
    Alchemy,
    Buff,
    Other
}