using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAudioPlayer : MonoBehaviour
{
    [SerializeField]
    private UIAudioType audioType;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(Play);
        }
    }

    private void Play()
    {
        AudioManager.Instance.PlayUI(audioType);
    }
}
