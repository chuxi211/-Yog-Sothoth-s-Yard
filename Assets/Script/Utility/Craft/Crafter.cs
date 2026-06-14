using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter
{
    private Inventory Inventory;
    private RecipeDataBase RecipeDataBase;  
    public Crafter(Inventory inventory, RecipeDataBase recipeDataBase)
    {
        Inventory = inventory;
        RecipeDataBase = recipeDataBase;
    }

    public ItemRunning Craft(Recipe recipe)
    {
        foreach(var rawMaterial in  recipe.RawMaterials)
        {
            Inventory.ChangeItemCount(rawMaterial.Item.ID, -rawMaterial.Count);
        }
        Inventory.ChangeItemCount(recipe.Output.Item.ID, recipe.Output.Count);
        return new ItemRunning(recipe.Output.Item, recipe.Output.Count);
    }
}