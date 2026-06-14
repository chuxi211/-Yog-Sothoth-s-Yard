using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DropSystem
{
    public static List<ItemRunning> Generate(NPCRunning npc)
    {
        int total=npc.candidates.Sum<DropEntry>(x => x.Weight);
        List<ItemRunning> items = new List<ItemRunning>();
        int current = 0;
        foreach(var entry in npc.candidates)
        {
            current += entry.Weight;
            int count = Random.Range(entry.MinCount, entry.MaxCount + 1);
            if (Random.Range(0, total) < current)
            {
                items.Add(new ItemRunning(entry.Item, count));
            }
        }
        return items;
    }
    public static List<ItemRunning> Generate(ForestExploreRunning forestExplore)
    {
        int total = forestExplore.candidate.Sum<DropEntry>(x => x.Weight);
        List<ItemRunning> items = new List<ItemRunning>();
        int current = 0;
        foreach(var entry in forestExplore.candidate)
        {
            current += entry.Weight;
            int count = Random.Range(entry.MinCount, entry.MaxCount + 1);
            if (entry.Item == null)
            {
                Debug.LogError("DropEntry.Item is null");
                continue;
            }
            if (Random.Range(0, total) < current)
            {
                items.Add(new ItemRunning(entry.Item, count));
            }
        }
        return items;
    }
}