using Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCConfigLoader : IAssetService<NPCConfig>
{
    public NPCConfig Load(string path)
    {
        throw new System.NotImplementedException();
    }

    public List<NPCConfig> LoadAll(string path)
    {
        return Resources.LoadAll<NPCConfig>(path).ToList();
    }

    public List<NPCConfig> LoadAllAsync(string path)
    {
        throw new System.NotImplementedException();
    }

    public NPCConfig LoadAsync(string path)
    {
        throw new System.NotImplementedException();
    }
}