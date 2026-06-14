using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HotelLevelDataBase
{
    public Dictionary<int, HotelLevelConfigTable> Configs = new();
    public HotelLevelDataBase()
    {
        Resources.LoadAll<HotelLevelConfigTable>("ConfigureInfo/HotelLevelConfig")?.ToList().ForEach(info => Configs[info.Level] = info);
    }
    public HotelLevelConfigTable GetConfigInfo(int Level)
    {
        if(!Configs.TryGetValue(Level,out var config))
        {
            Debug.Log($"HotelLevel:{Level} config is null");
            return null;
        }
        return config;
    }
}