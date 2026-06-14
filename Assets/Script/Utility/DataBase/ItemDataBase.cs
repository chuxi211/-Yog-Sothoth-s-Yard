using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemDataBase
{
    private Dictionary<string , ItemConfigureInfo> ConfigureInfos=new Dictionary<string , ItemConfigureInfo>();
    public ItemDataBase()
    {
        Resources.LoadAll<ItemConfigureInfo>("ConfigureInfo/ItemsConfig").ToList().ForEach(info => ConfigureInfos[info.ID] = info);
    }
    public ItemConfigureInfo GetConfigureInfo(string id)
    {
        if (ConfigureInfos.TryGetValue(id, out ItemConfigureInfo info))
        {
            return info;
        }
        return null;
    }
}