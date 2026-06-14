using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLoader : IAssetService<GameObject>
{
    public GameObject Load(string path)
    {
        return Resources.Load<GameObject>(path);
    }

    public List<GameObject> LoadAll(string path)
    {
        throw new System.NotImplementedException();
    }

    public List<GameObject> LoadAllAsync(string path)
    {
        throw new System.NotImplementedException();
    }

    public GameObject LoadAsync(string path)
    {
        throw new System.NotImplementedException();
    }
}
