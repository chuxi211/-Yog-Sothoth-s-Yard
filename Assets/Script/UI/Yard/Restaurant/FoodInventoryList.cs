using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInventoryList : MonoBehaviour
{
    private RestaurantComponent Restaurant;
    private List<FoodInventoryContainer> FoodInventoryContainers=new();
    private List<ItemRunning> SellingCandidate=new();
    private GameObject Prefab;
    private PrefabLoader PrefabLoader;
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
        SellingCandidate=Restaurant.GetSellingCandidate();
        Prefab = PrefabLoader.Load("Prefab/Restaurant/FoodInventoryContainer");
        for (int i = 0; i < SellingCandidate.Count; i++)
        {
            GameObject gameObject = Instantiate(Prefab, transform);
            if (!gameObject.TryGetComponent<FoodInventoryContainer>(out FoodInventoryContainer container))
            {
                container = gameObject.AddComponent<FoodInventoryContainer>();
            }
            container.Init(i);
            FoodInventoryContainers.Add(container);
        }
    }
    public void Refresh()
    {
        SellingCandidate = Restaurant.GetSellingCandidate();
        for (int i = 0; i < FoodInventoryContainers.Count; i++)
        {
            if (i < SellingCandidate.Count)
            {
                FoodInventoryContainers[i].Refresh(SellingCandidate[i]);
            }
            else
            {
                FoodInventoryContainers[i].Refresh(null);
            }
        }
    }
}
