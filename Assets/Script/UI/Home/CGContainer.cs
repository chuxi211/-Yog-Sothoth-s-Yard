using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGContainer : MonoBehaviour
{
    public Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void SetCG(Sprite sprite)
    {
        if(sprite == null)
        {
            image.sprite = null;
            image.color = new Color(1, 1, 1, 0);
        }
        image.sprite = sprite;
        image.color = new Color(1, 1, 1, 1);
    }
}
