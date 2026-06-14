using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    private GameObject ItemContainerPrefab;
    private PrefabLoader PrefabLoader;
    private List<ItemContainer> ItemContainers;
    private Inventory Inventory;
    private void Awake()
    {
        PrefabLoader=new PrefabLoader();
        ItemContainers = new List<ItemContainer>();
        ItemContainerPrefab = PrefabLoader.Load("Prefab/ItemContainer");
    }
    public void Init(Inventory inventory)
    {
        Inventory = inventory;
    }
    private void OnEnable()
    {
        EventBus.Subscribe<ItemChangedEvent>(Refresh);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<ItemChangedEvent>(Refresh);
    }
    private void Refresh(ItemChangedEvent e)
    {
        Clear();
        foreach(var item in Inventory.GetAllItems())
        {
            Create();
            if (item.Value.Item == null)
            {
                Debug.LogError($"{item.Value.Item}.Icon not found.");
            }
            ItemContainers[ItemContainers.Count - 1].Refresh(item.Value);
        }
    }
    private void Create()
    {
        GameObject Item=GameObject.Instantiate(ItemContainerPrefab,transform);
        ItemContainer itemContainer = Item.GetComponent<ItemContainer>();
        ItemContainers.Add(itemContainer);
    }
    private void Clear()
    {
        foreach (var item in ItemContainers)
        {
            Destroy(item.gameObject);
        }
        ItemContainers.Clear();
    }
}
