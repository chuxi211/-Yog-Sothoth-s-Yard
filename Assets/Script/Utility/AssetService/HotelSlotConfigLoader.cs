using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.RunningHotel;
using Data.ConfigureHotel;
using System.Linq;
public class HotelSlotConfigLoader : IAssetService<HotelSlotConfig>
{
    public HotelSlotConfig Load(string path)
    {
        return Resources.Load<HotelSlotConfig>(path);
    }

    public List<HotelSlotConfig> LoadAll(string path)
    {
        return Resources.LoadAll<HotelSlotConfig>(path).OrderBy(x => x.Layer.Layer).ToList();
    }

    public List<HotelSlotConfig> LoadAllAsync(string path)
    {
        return Resources.LoadAll<HotelSlotConfig>(path).OrderBy(x => x.Layer.Layer).ToList();
    }

    public HotelSlotConfig LoadAsync(string path)
    {
        throw new System.NotImplementedException();
    }
}
