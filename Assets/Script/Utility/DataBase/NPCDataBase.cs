using Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCDataBase
{
    public Dictionary<string,NPCConfig> NPCConfigBase=new Dictionary<string,NPCConfig>();
    public List<NPCConfig> NPCConfigList = new();
    public NPCDataBase()
    {
        new NPCConfigLoader().LoadAll("ConfigureInfo/NPCConfig").ForEach(config => NPCConfigBase[config.ID] = config);
        Debug.Log($"NPCConfigNum:{NPCConfigBase.Count}");
        NPCConfigList = Resources.LoadAll<NPCConfig>("ConfigureInfo/NPCConfig").ToList();
        Debug.Log($"NPCConfigNum:{NPCConfigList.Count}");
    }
    public NPCConfig GetNPCConfigByID(string id)
    {
        if (!NPCConfigBase.TryGetValue(id, out NPCConfig config))
        {
            Debug.Log($"This {id} is not found");
            return null;
        }
        return config;
    }
    public List<NPCConfig> GetNPCConfigByLevel(int Level)
    {
        return NPCConfigList.Where(x => x.Level <= Level).ToList();
    }
}