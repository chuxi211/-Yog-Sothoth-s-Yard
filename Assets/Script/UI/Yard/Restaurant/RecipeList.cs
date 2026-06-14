using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeList : MonoBehaviour
{
    private GameObject Prefab;
    private List<RecipeContainer> RecipeContainers = new List<RecipeContainer>();
    private PrefabLoader PrefabLoader;
    private RecipeDataBase RecipeDataBase;
    [SerializeField]
    private Transform Content;
    public void BindPrefabLoader(PrefabLoader loader)
    {
        PrefabLoader = loader;
    }
    public void BindRecipeDataBase(RecipeDataBase recipeDataBase)
    {
        RecipeDataBase = recipeDataBase;
    }
    public void Init()
    {
        Prefab = PrefabLoader.Load("Prefab/Restaurant/RecipeContainer");
        for (int i = 0; i < RecipeDataBase.recipes.Count; i++)
        {
            GameObject Container = Instantiate(Prefab, Content);
            if (!Container.TryGetComponent<RecipeContainer>(out RecipeContainer recipeContainer))
            {
                recipeContainer = Container.AddComponent<RecipeContainer>();
            }

            recipeContainer.BindRecipe(RecipeDataBase.GetAllRecipe().ToArray()[i]);
            RecipeContainers.Add(recipeContainer);
        }
        Refresh();
    }
    public void Refresh()
    {
        foreach(var container in RecipeContainers)
        {
            container.Refresh();
        }
    }
}
