using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NPCDropTable",menuName ="ScriptableObjects/DropTable/NPCDropTable")]
[Serializable]
public class NPCDropConfigTable:ScriptableObject
{
    public List<DropEntry> dropEntries;
}
[Serializable]
public class DropEntry{
    public ItemConfigureInfo Item;
    public int Weight;
    public int MaxCount;
    public int MinCount;
}