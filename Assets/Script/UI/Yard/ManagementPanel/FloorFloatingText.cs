using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloorFloatingText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        EventBus.Subscribe<FloorSwitchedEvent>(OnFloorSwitched);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<FloorSwitchedEvent>(OnFloorSwitched);
    }
    private void OnFloorSwitched(FloorSwitchedEvent e)
    {
        if (e.floor == 0)
        {
            text.text = "Í¥Ôº";
        }
        else
        {
            text.text = "ÂÃÉç" + e.floor + "²ã";
        }
    }
}
