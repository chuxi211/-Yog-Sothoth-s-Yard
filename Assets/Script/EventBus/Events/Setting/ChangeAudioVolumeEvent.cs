using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudioVolumeEvent
{
    public float volume;
    public ChangeAudioVolumeEvent(float volume)
    {
        this.volume = volume;
    }
}