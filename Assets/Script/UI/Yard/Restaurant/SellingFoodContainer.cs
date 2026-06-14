using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Restaurant界面的五个展示栏位
public class SellingFoodContainer : MonoBehaviour
{
    [SerializeField]
    private Image Icon;
    [SerializeField]
    private TextMeshProUGUI Name;
    [SerializeField]
    private TextMeshProUGUI MaxNum;
    [SerializeField]
    private TextMeshProUGUI CurrentNum;
    [SerializeField]
    private TextMeshProUGUI Price;
    [SerializeField]
    private Sprite EmptyIcon;
    private int Index;
    public void Init(int index)
    {
        Index= index;
    }
    public void Refresh(ItemConfigureInfo configinfo,SellingSlotInfo slotinfo)
    {
        if (configinfo == null)
        {
            Icon.sprite = EmptyIcon;
            Name.text = null;
        }
        Icon.sprite = configinfo.Icon;
        Name.text = configinfo.Name;
        MaxNum.text = slotinfo.MaxCount.ToString();
        CurrentNum.text = slotinfo.CurrentCount.ToString();
    }
}
