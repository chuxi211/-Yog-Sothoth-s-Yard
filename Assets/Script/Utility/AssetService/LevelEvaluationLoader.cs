using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelEvaluationLoader : IAssetService<HotelLevelConfigTable>
{
    public HotelLevelConfigTable Load(string path)
    {
        throw new System.NotImplementedException();
    }

    public List<HotelLevelConfigTable> LoadAll(string path)
    {
        return Resources.LoadAll<HotelLevelConfigTable>(path).ToList();
    }

    public List<HotelLevelConfigTable> LoadAllAsync(string path)
    {
        throw new System.NotImplementedException();
    }

    public HotelLevelConfigTable LoadAsync(string path)
    {
        throw new System.NotImplementedException();
    }
}
