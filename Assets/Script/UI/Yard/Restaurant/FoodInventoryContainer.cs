using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//显示Inventory中所有Type为Food的ItemRunning，显示Icon、Name、Price和Level
public class FoodInventoryContainer : MonoBehaviour
{
    [SerializeField]
    private Image Icon;
    [SerializeField]
    private Image Frame;
    [SerializeField]
    private TextMeshProUGUI Name;
    [SerializeField]
    private TextMeshProUGUI PriceCounter;
    [SerializeField]
    private TextMeshProUGUI IndexCounter;
    [SerializeField]
    private Sprite[] Rarity;
    [SerializeField]
    private Button AddButton;
    private ItemRunning ItemRunning;
    private int Index;
    private void Awake()
    {
        AddButton.onClick.AddListener(OnAddButtonClicked);
    }
    private void OnDestroy()
    {
        AddButton.onClick.RemoveListener(OnAddButtonClicked);
    }
    public void Init(int index)
    {
        Index = index;
    }
    public void Refresh(ItemRunning itemRunning)
    {
        ItemRunning = itemRunning;
        Icon.sprite = itemRunning.Item.Icon;
        Name.text = itemRunning.Item.Name;
        PriceCounter.text = itemRunning.Item.Price.ToString();
        Frame.sprite=Rarity[itemRunning.Item.Level - 1];
    }
    private void OnAddButtonClicked()
    {
        EventBus.Publish(new AddToEditorMenuEvent(ItemRunning.Item.ID,ItemRunning.Count));
    }
}
