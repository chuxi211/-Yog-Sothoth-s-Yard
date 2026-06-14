using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipeDataBase
{
    public List<Recipe> recipes { get;private set; }
    private RecipeLoader Loader;
    public RecipeDataBase(RecipeLoader loader)
    {
        recipes = new List<Recipe>();
        Loader = loader;
        recipes= Loader.LoadAll("ConfigureInfo/Recipe");
    }
    public List<Recipe> GetAllRecipe()
    {
        return recipes;
    }
}