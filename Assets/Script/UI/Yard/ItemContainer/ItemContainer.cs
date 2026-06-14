using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemContainer : MonoBehaviour
{
    public Sprite[] Rarity;
    public Image Edge { get; private set; }
    public Image image { get; private set; }
    public TextMeshProUGUI textMesh { get; private set; }
    public ItemRunning Item { get;private set; }
    private void Awake()
    {
        Edge = GetComponent<Image>();
        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            if (image.gameObject != this.gameObject)
            {
                this.image = image;
                break;
            }
        }
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void Refresh(ItemRunning item)
    {
        this.Item = item;
        if (item == null)
        {
            Debug.LogError("ItemRunning is null");
        }
        if(item.Item == null)
        {
            Debug.LogError("ItemConfig is null");
        }
        if (item.Item.Icon == null)
        {
            Debug.LogError("ItemConfig.Icon is null");
        }
        Edge.sprite=Rarity[item.Item.Level-1];
        image.sprite = item.Item.Icon;
        textMesh.text = item.Count.ToString();
    }
}