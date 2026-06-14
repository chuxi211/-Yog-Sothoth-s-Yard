using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFactory
{
    public NPCRunning CreateNPC(NPCConfig npcConfig)
    {
        NPCRunning npcRunning = new NPCRunning(npcConfig);
        GameObject npcObject = new GameObject(npcRunning.Name);
        npcObject.AddComponent<SpriteRenderer>().sprite = npcConfig.Avater;
        NPCActor actor = npcObject.GetComponent<NPCActor>();
        if (!actor)
        {
            actor = npcObject.AddComponent<NPCActor>();
        }
        actor.Init(npcRunning);
        npcRunning.BindActor(actor);
        return npcRunning;
    }
    public List<NPCRunning> CreateNPCs(List<NPCConfig> npcConfigs)
    {
        Debug.Log($"CreateNPCs called, count = {npcConfigs.Count}");
        List<NPCRunning> npcs = new();
        foreach(var npcConfig in npcConfigs)
        {
            NPCRunning npcRunning = new NPCRunning(npcConfig);
            GameObject npcObject = new GameObject(npcRunning.Name);
            Debug.Log($"Create NPC: {npcRunning.Name}, Sprite: {npcConfig.Avater}");
            npcObject.AddComponent<SpriteRenderer>().sprite = npcConfig.Avater;
            NPCActor actor=npcObject.GetComponent<NPCActor>();
            if (!actor)
            {
                actor= npcObject.AddComponent<NPCActor>();
            }
            actor.Init(npcRunning);
            npcRunning.BindActor(actor);
            npcs.Add(npcRunning);
        }
        return npcs;
    }
}