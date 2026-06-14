using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRunning
{
    public ItemConfigureInfo Item { get; private set; }
    public int Count { get; private set; }
    public ItemRunning(ItemConfigureInfo item, int count)
    {
        Item = item;
        Count = count;
    }
    public void Add(int amount)
    {
        Count += amount;
    }
    public void Remove(int amount)
    {
        Count -= amount;
        if (Count <= 0)
        {
            Count = 0;
        }
    }
}