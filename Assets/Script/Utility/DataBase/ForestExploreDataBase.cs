using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ForestExploreDataBase
{
    private Dictionary<ExploreRegion ,ForestExploreConfigInfo> ConfigInfos = new();
    public ForestExploreDataBase()
    {
        //所有的数据都是构造时直接LoadAll的。
        //后续改为构造时实例Loader
        //按需懒加载资源
        ConfigInfos = Resources.LoadAll<ForestExploreConfigInfo>("ConfigureInfo/ExploreConfig").ToDictionary(x => x.ExploreRegion);
    }
    public void Load(ExploreRegion exploreRegion)
    {
        
    }
    public bool TryGetConfigInfoByRegion(ExploreRegion exploreRegion,out ForestExploreConfigInfo configinfo)
    {
        if(ConfigInfos.TryGetValue(exploreRegion,out configinfo))
        {
            return true;
        }
        return false;
    }
}