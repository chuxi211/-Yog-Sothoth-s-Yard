using Command.Management;
using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuEditorList : MonoBehaviour
{
    private RestaurantComponent Restaurant;
    private GameObject Prefab;
    private PrefabLoader PrefabLoader;
    private CommandInvoker Invoker;
    private List<MenuEditorContainer> MenuEditorContainers = new();
    private List<SellingSlotInfo> EditingMenuSlots = new();
    private void OnEnable()
    {
        EventBus.Subscribe<OpenModifyMenuPanelEvent>(Open);
        EventBus.Subscribe<AddToEditorMenuEvent>(AddSlot);
        EventBus.Subscribe<RemoveEditorMenuEvent>(RemoveSlot);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<OpenModifyMenuPanelEvent>(Open);
        EventBus.UnSubscribe<AddToEditorMenuEvent>(AddSlot);
        EventBus.UnSubscribe<RemoveEditorMenuEvent>(RemoveSlot);
    }

    public void BindRestaurant(RestaurantComponent restaurant)
    {
        Restaurant = restaurant;
    }
    public void BindPrefabLoader(PrefabLoader loader)
    {
        PrefabLoader = loader;
    }
    public void BindCommandInvoker(CommandInvoker invoker)
    {
        Invoker = invoker;
    }
    public void Init()
    {
        Prefab = PrefabLoader.Load("Prefab/Restaurant/MenuEditorContainer");
        for (int i = 0; i < RestaurantComponent.MaxSellingNum; i++)
        {
            GameObject Container = Instantiate(Prefab, transform);
            if (!Container.TryGetComponent<MenuEditorContainer>(out MenuEditorContainer menuEditorContainer))
            {
                menuEditorContainer = Container.AddComponent<MenuEditorContainer>();
            }
            menuEditorContainer.Init(i);
            MenuEditorContainers.Add(menuEditorContainer);
        }
    }
    public void Open(OpenModifyMenuPanelEvent e)
    {
        CopySellingToEditor();
        Refresh();
    }
    private void RemoveSlot(RemoveEditorMenuEvent e)
    {
        if (e.Index < Restaurant.SellingSlotInfos.Count)
        {
            EditingMenuSlots[e.Index].Clear();
            Refresh();
        }
    }
    private void AddSlot(AddToEditorMenuEvent e)
    {
        SellingSlotInfo slotInfo = EditingMenuSlots.Where(x=>x.FoodID==null).FirstOrDefault();
        if (slotInfo != null)
        {
            slotInfo.FoodID = e.FoodID;
            slotInfo.CurrentCount = Mathf.Min(e.Count, slotInfo.MaxCount);
        }
    }
    private void CopySellingToEditor() 
    {
        EditingMenuSlots.Clear();
        foreach (var slotinfo in Restaurant.SellingSlotInfos)
        {
            SellingSlotInfo copy = slotinfo.Clone();
            EditingMenuSlots.Add(copy);
        }
    }
    public void Refresh()
    {
        for (int i = 0; i < MenuEditorContainers.Count; i++)
        {
            if (i < Restaurant.SellingSlotInfos.Count)
            {
                MenuEditorContainers[i].Refresh(Restaurant.itemDataBase.GetConfigureInfo(EditingMenuSlots[i].FoodID),
                                        EditingMenuSlots[i]);
            }
            else
            {
                MenuEditorContainers[i].Refresh(null,null);
            }
        }
    }
    private void ConfirmEdit()
    {
        Invoker.Execute(new SetRestaurantMenuCommand(EditingMenuSlots));
    }
}
