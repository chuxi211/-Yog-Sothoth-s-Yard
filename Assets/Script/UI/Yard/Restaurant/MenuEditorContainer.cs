using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuEditorContainer : MonoBehaviour
{
    [SerializeField]
    private Image Icon;
    [SerializeField]
    private Image RarityFrame;
    [SerializeField]
    private TextMeshProUGUI Name;
    [SerializeField]
    private TextMeshProUGUI MaxNum;
    [SerializeField]
    private TextMeshProUGUI CurrentNum;
    [SerializeField]
    private Sprite[] Rarity;
    [SerializeField]
    private Button RemoveButton;
    private int Index;
    private void Awake()
    {
        RemoveButton.onClick.AddListener(OnRemoveButtonClick);
    }
    private void OnDestroy()
    {
        RemoveButton.onClick.RemoveListener(OnRemoveButtonClick);
    }
    public void Init(int index)
    {
        Index = index;
    }
    public void Refresh(ItemConfigureInfo configinfo,SellingSlotInfo slotinfo)
    {
        if (configinfo != null && slotinfo != null)
        {
            Icon.sprite = configinfo.Icon;
            Name.text = configinfo.Name;
            RarityFrame.sprite = Rarity[configinfo.Level - 1];
            MaxNum.text = "/" + slotinfo.MaxCount.ToString();
            CurrentNum.text = slotinfo.CurrentCount.ToString();
        }
        else
        {
            Icon.sprite = null;
            Icon.color = new Color(1, 1, 1, 0);
            Name.text = null;
            RarityFrame.sprite= null;
            RarityFrame.color = new Color(1, 1, 1, 0);
            MaxNum.text = null;
            CurrentNum.text = null;
        }
    }
    private void OnRemoveButtonClick()
    {
        EventBus.Publish(new RemoveEditorMenuEvent(Index));
    }
}
