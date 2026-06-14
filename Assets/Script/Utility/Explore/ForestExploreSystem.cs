using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ForestExploreSystem
{
    private ForestExploreDataBase DataBase;
    //同时只能有一个森林探索在进行
    private static ForestExploreRunning ForestRunning;
    private Inventory inventory;
    public ForestExploreSystem(Inventory inventory, ForestExploreDataBase dataBase)
    {
        this.inventory = inventory;
        this.DataBase = dataBase;
        EventBus.Subscribe<DayNightSwitchedEvent>(Advance);
    }
    public bool TryStartExplore(ExploreRegion exploreRegion)
    {
        if (ForestRunning != null)
        {
            Debug.LogError("Already have a explore running");
            return false;
        }
        if (DataBase.TryGetConfigInfoByRegion(exploreRegion,out ForestExploreConfigInfo configinfo))
        {
            ForestRunning = new ForestExploreRunning(configinfo);
            return true;
        }
        return false;
    }
    private void Advance(DayNightSwitchedEvent e)
    {
        if (ForestRunning != null)
        {
            ForestRunning.ConsumeTimePeriod--;
            if (ForestRunning.ConsumeTimePeriod <= 0)
            {
                FinishExplore();
            }
        }
    }
    private void FinishExplore()
    {
        AddItemsToInventory(DropSystem.Generate(ForestRunning));
        ForestRunning = null;
    }
    private void AddItemsToInventory(List<ItemRunning> items)
    {
        foreach (var item in items)
        {
            //改成Command
            if(item == null)
            {
                Debug.LogError("Item is null");
                break;
            }
            if (item.Item == null)
            {
                Debug.LogError("Item ID is null");
            }
            if (inventory == null)
            {
                Debug.LogError("Inventory is null"); break;
            }
            inventory.ChangeItemCount(item.Item.ID, item.Count);
        }
    }
}