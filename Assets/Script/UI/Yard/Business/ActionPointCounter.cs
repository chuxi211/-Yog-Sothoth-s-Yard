using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionPointCounter : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        EventBus.Subscribe<ActionPointChangedEvent>(UpdateActionPointValue);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<ActionPointChangedEvent>(UpdateActionPointValue);
    }
    private void UpdateActionPointValue(ActionPointChangedEvent e)
    {
        textMesh.text = e.ActionPoint.ToString();
    }
}
