using Data.ConfigureHotel;
using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurantComponentBuilder : IComponentBuilder
{
    private NPCDataBase npcDataBase;
    private ItemDataBase itemDataBase;
    private NPCFactory npcFactory;
    private Inventory Inventory;
    public RestaurantComponentBuilder(NPCDataBase npcDataBase,ItemDataBase itemDataBase, NPCFactory npcFactory, Inventory inventory)
    {
        this.npcDataBase = npcDataBase;
        this.itemDataBase = itemDataBase;
        this.npcFactory = npcFactory;
        Inventory = inventory;
    }
    public void BuildComponent(RoomRunning roomRunning,RoomLevelConfig levelConfig)
    {
        var restaurantcmp = new RestaurantComponent();
        restaurantcmp.BindNPCDataBase(npcDataBase);
        restaurantcmp.BindNPCFactory(npcFactory);
        restaurantcmp.BindInventory(Inventory);
        restaurantcmp.BindItemDataBase(itemDataBase);
        restaurantcmp.ApplyLevel(levelConfig);
        roomRunning.AddComponent(restaurantcmp);
    }
}
