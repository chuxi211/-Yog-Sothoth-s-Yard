using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EvilCounter : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        EventBus.Subscribe<EvilValueChangedEvent>(OnEvilValueChanged);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<EvilValueChangedEvent>(OnEvilValueChanged);
    }
    private void OnEvilValueChanged(EvilValueChangedEvent e)
    {
        textMesh.text = e.value.ToString()+"%";
    }
}
