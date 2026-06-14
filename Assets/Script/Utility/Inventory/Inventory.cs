using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private Dictionary<string, ItemRunning> items;
    private ItemDataBase itemDataBase;
    public Inventory(ItemDataBase itemDataBase)
    {
        items = new Dictionary<string, ItemRunning>();
        this.itemDataBase = itemDataBase;
    }
    public void ChangeItemCount(string ID,int count)
    {
        if (count == 0) return;
        if (count > 0)
        {
            AddItem(ID, count);
        }
        if (count < 0)
        {
            RemoveItem(ID, -count);
        }
    }
    private void AddItem(string id, int count)
    {
        if (items.TryGetValue(id,out ItemRunning itemRunning))
        {
            itemRunning.Add(count);
        }
        else
        {
            items[id] = new ItemRunning(itemDataBase.GetConfigureInfo(id), count);
        }
        EventBus.Publish(new ItemChangedEvent());
    }
    private void RemoveItem(string itemId, int count)
    {
        if(items.TryGetValue(itemId, out ItemRunning itemRunning))
        {
            itemRunning.Remove(count);
            if (itemRunning.Count <= 0)
            {
                items.Remove(itemId);
            }
        }
    }
    public Dictionary<string, ItemRunning> GetAllItems()
    {
        Debug.Log(items.Count);
        foreach(var item in items)
        {
            Debug.Log(item.Value.Item.name);
        }
        return items;
    }
    public int GetItemCount(string itemId)
    {
        if( items.TryGetValue(itemId,out ItemRunning itemRunning)){
            return itemRunning.Count;
        }
        return 0;
    }
    public ItemRunning GetItem(string itemId)
    {
        if(items.TryGetValue(itemId,out ItemRunning itemRunning))
        {
            return itemRunning;
        }
        return null;
    }
    public bool HasItem(string itemId)
    {
        return items.ContainsKey(itemId) && items[itemId].Count > 0;
    }
}