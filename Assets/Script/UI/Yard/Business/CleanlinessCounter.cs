using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CleanlinessCounter : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        EventBus.Subscribe<CleanlinessValueChangedEvent>(UpdateCleanlinessValue);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<CleanlinessValueChangedEvent>(UpdateCleanlinessValue);
    }
    private void UpdateCleanlinessValue(CleanlinessValueChangedEvent e)
    {
        textMesh.text = e.value.ToString();
        textMesh.enableAutoSizing = true;
    }
}
