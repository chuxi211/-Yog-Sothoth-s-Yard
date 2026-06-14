using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Recipe", menuName = "ConfigInfo/Recipe")]
[Serializable]
public class Recipe : ScriptableObject
{
    public List<RecipeItem> RawMaterials;
    public RecipeItem Output;
    public RecipeType Type;
}
[Serializable]
public class RecipeItem
{
    public ItemConfigureInfo Item;
    public int Count;
}
public enum RecipeType
{
    Cooking,
    Alchemy,
}