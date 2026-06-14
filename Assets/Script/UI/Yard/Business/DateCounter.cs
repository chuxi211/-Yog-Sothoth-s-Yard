using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateCounter : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        EventBus.Subscribe<DateSwitchedEvent>(UpdateDate);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<DateSwitchedEvent>(UpdateDate);
    }
    private void UpdateDate(DateSwitchedEvent e)
    {
        textMesh.text="Week"+e.Week.ToString()+"Day"+e.Day.ToString();
    }
}
