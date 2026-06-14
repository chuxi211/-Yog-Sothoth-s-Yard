using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSilder : MonoBehaviour
{
    private Slider slider;
    public void PublishValue(float value)
    {
        EventBus.Publish(new ChangeAudioVolumeEvent(value));
    }
}
