using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingFoodList : MonoBehaviour
{
    private List<SellingFoodContainer> FoodContainers = new List<SellingFoodContainer>();
    private GameObject Prefab;
    private RestaurantComponent Restaurant;
    private PrefabLoader PrefabLoader;
    [SerializeField]
    private Transform Content;
    private void OnEnable()
    {
        EventBus.Subscribe<SellingFoodChangedEvent>(Refresh);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<SellingFoodChangedEvent>(Refresh);
    }
    public void BindRestaurant(RestaurantComponent restaurant)
    {
        Restaurant = restaurant;
    }
    public void BindPrefabLoader(PrefabLoader loader)
    {
        PrefabLoader = loader;
    }
    public void Init()
    {
        if (FoodContainers.Count > 0) { return; }
        Prefab = PrefabLoader.Load("Prefab/Restaurant/SellingFoodContainer");
        for (int i = 0; i < RestaurantComponent.MaxSellingNum; i++)
        {
            GameObject Container = Instantiate(Prefab, Content);
            if (!Container.TryGetComponent<SellingFoodContainer>(out SellingFoodContainer foodContainer))
            {
                foodContainer = Container.AddComponent<SellingFoodContainer>();
            }
            foodContainer.Init(i);
            FoodContainers.Add(foodContainer);
        }

    }
    
    public void Refresh(SellingFoodChangedEvent e)
    {
        for(int i = 0; i < FoodContainers.Count; i++)
        {
            if (i < Restaurant.SellingSlotInfos.Count)
            {
                FoodContainers[i].Refresh(Restaurant.itemDataBase.GetConfigureInfo(Restaurant.SellingSlotInfos[i].FoodID)
                                           , Restaurant.SellingSlotInfos[i]);
            }
            else
            {
                FoodContainers[i].Refresh(null, null);
            }
        }
    }
}
