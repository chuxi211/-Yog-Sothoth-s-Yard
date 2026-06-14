using Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomDetailPage : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] SpriteRenderer;
    [SerializeField]
    private TextMeshPro RoomID;
    [SerializeField]
    private TextMeshPro Level;
    [SerializeField]
    private TextMeshPro Upgrade;
    [SerializeField]
    private Collider[] colliders;
    public void Hide()
    {
        SetVisible(false);
    }
    public void Show()
    {
        SetVisible(true);
    }
    public void SetTexts(RoomID roomID,int level)
    {
        RoomID.text = "·¿¼ä" + roomID.Floor.ToString()+"0"+roomID.Index.ToString();
        RoomID.enableWordWrapping = false;
        RoomID.fontSize = 10;
        Level.text="Lv."+level.ToString();
    }
    private void SetVisible(bool visible)
    {
        foreach (var r in SpriteRenderer)
        {
            var c = r.color;
            c.a = visible ? 1f : 0f;
            r.color = c;
        }

        RoomID.alpha = visible ? 1f : 0f;
        Level.alpha = visible ? 1f : 0f;
        Upgrade.alpha = visible ? 1f : 0f;

        foreach (var c in colliders)
        {
            c.enabled = visible;
        }
    }
}
