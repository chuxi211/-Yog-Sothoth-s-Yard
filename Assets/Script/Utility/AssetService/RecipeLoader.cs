using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipeLoader : IAssetService<Recipe>
{
    public Recipe Load(string path)
    {
        return Resources.Load<Recipe>(path);
    }

    public List<Recipe> LoadAll(string path)
    {
        return Resources.LoadAll<Recipe>(path).ToList();
    }

    public List<Recipe> LoadAllAsync(string path)
    {
        throw new System.NotImplementedException();
    }

    public Recipe LoadAsync(string path)
    {
        throw new System.NotImplementedException();
    }
}