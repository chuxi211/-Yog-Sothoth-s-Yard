using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class UIButton<T> : MonoBehaviour where T:new()
{
    public void OnClick()
    {
        EventBus.Publish(new T());
    }
}
