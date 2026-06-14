using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class SoulCounter : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        EventBus.Subscribe<SoulValueChangedEvent>(OnSoulValueChanged);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<SoulValueChangedEvent>(OnSoulValueChanged);
    }
    private void OnSoulValueChanged(SoulValueChangedEvent e)
    {
        textMesh.text = e.value.ToString();
    }
}