using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDetailEvent
{
    public Recipe Recipe;
    public RecipeDetailEvent(Recipe recipe)
    {
        Recipe = recipe;
    }
}