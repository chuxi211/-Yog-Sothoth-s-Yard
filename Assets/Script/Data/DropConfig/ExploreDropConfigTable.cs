using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ExploreDropConfigTable", menuName = "ScriptableObjects/DropTable/ExploreDropConfigTable")]
[Serializable]
public class ExploreDropConfigTable : ScriptableObject
{
    [SerializeField] public List<DropEntry> dropEntries;
}