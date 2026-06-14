using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        EventBus.Subscribe<CoinValueChangedEvent>(OnCoinValueChanged);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<CoinValueChangedEvent>(OnCoinValueChanged);
    }
    private void OnCoinValueChanged(CoinValueChangedEvent e)
    {
        textMesh.text = e.value.ToString();
    }
}