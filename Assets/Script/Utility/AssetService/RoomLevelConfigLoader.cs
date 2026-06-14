using Data.ConfigureHotel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomLevelConfigLoader : IAssetService<RoomLevelConfig>
{
    public RoomLevelConfig Load(string path)
    {
        return Resources.Load<RoomLevelConfig>(path);
    }

    public List<RoomLevelConfig> LoadAll(string path)
    {
        return Resources.LoadAll<RoomLevelConfig>(path).ToList();
    }

    public List<RoomLevelConfig> LoadAllAsync(string path)
    {
        throw new System.NotImplementedException();
    }

    public RoomLevelConfig LoadAsync(string path)
    {
        throw new System.NotImplementedException();
    }
}