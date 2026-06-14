using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SanCounter : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        EventBus.Subscribe<SANValueChangedEvent>(OnSanValueChanged);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<SANValueChangedEvent>(OnSanValueChanged);
    }
    private void OnSanValueChanged(SANValueChangedEvent e)
    {
        textMesh.text = e.value.ToString();
    }
}