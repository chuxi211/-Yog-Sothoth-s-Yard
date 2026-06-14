using Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCRunning
{
    public NPCConfig Config { get; private set; }
    public string Name { get; private set; }
    public string ID { get; private set; }
    public Feature Feature { get; private set; }
    public int Level { get;private set; }
    public int Coin { get; private set; }
    public int CoinDropRate { get; private set; }
    public int Soul { get; private set; }
    public int SoulDropRate { get; private set; }
    public int CleanlinessValue { get; private set; }
    public int StayDuration { get; private set; } = 2;
    //实际掉落的Item
    public List<ItemRunning> Items { get; private set; }
    //可能掉落的Item
    public List<DropEntry> candidates { get; private set; }
    public NPCActor Actor { get; private set; }
    public NPCRunning(NPCConfig npcConfig)
    {
        this.Config= npcConfig;
        Name = npcConfig.Name;
        ID = npcConfig.ID;
        Feature = npcConfig.Feature;
        Level = npcConfig.Level;
        Coin = npcConfig.MaxCoin;
        CoinDropRate = npcConfig.CoinDropRate;
        Soul = npcConfig.MaxSoul;
        SoulDropRate = npcConfig.SoulDropRate;
        CleanlinessValue = npcConfig.CleanlinessValue;
        //小于等于NPC等级的掉落项
        candidates = this.Config.DropTable.dropEntries.Where(x=>x.Item.Level<=this.Level).ToList();
    }
    public void UpdateStayDuration()
    {
        StayDuration--;
    }
    public void BindActor(NPCActor actor)
    {
        Actor = actor;
    }
}