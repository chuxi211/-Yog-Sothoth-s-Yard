using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField]
    public List<UIAudioEntry> UIAudioEntries;
    [SerializeField]
    public AudioSource UIAudioSource;
    [SerializeField]
    public List<BGMAudioEntry> BGMAudioTypes;
    [SerializeField]
    public AudioSource BGMSource;
    private Dictionary<UIAudioType, AudioClip> UIAudioDict = new();
    private Dictionary<BGMAudioType, AudioClip> BGMSourceDict = new();
    private float Volume;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance= this;
        DontDestroyOnLoad(Instance);
        foreach(var entry in UIAudioEntries)
        {
            UIAudioDict[entry.AudioType] = entry.Clip;
        }
        foreach(var entry in BGMAudioTypes)
        {
            BGMSourceDict[entry.AudioType] = entry.Clip;
        }
    }
    private void OnEnable()
    {
        EventBus.Subscribe<SwitchBGMEvent>(PlayBGM);
        EventBus.Subscribe<ChangeAudioVolumeEvent>(SwitchVolume);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<SwitchBGMEvent>(PlayBGM);
        EventBus.UnSubscribe<ChangeAudioVolumeEvent>(SwitchVolume);
    }
    private void SwitchVolume(ChangeAudioVolumeEvent e)
    {
        Volume = e.volume;
        UIAudioSource.volume = Volume;
        BGMSource.volume = Volume;
    }
    public void PlayUI(UIAudioType audioType)
    {
        if(UIAudioDict.TryGetValue(audioType, out var clip))
        {
            if(clip == null) { return; }
            UIAudioSource.clip= clip;
            UIAudioSource.PlayOneShot(clip);
        }
    }
    public void PlayBGM(BGMAudioType audioType)
    {
        if (BGMSourceDict.TryGetValue(audioType, out var clip))
        {
            if (clip == null) { return; }
            BGMSource.clip = clip;
            BGMSource.loop = true;
            BGMSource.Play();
        }
    }
    public void PlayBGM(SwitchBGMEvent e)
    {
        PlayBGM(e.AudioType);
    }
    public void StopBGM(BGMAudioType audioType)
    {
        if (BGMSourceDict.TryGetValue(audioType, out var clip))
        {
            if (clip == null) { return; }
            BGMSource.Stop();
        }
    }
}
[Serializable]
public class UIAudioEntry
{
    [SerializeField]
    public AudioClip Clip;
    [SerializeField]
    public UIAudioType AudioType;
}
[Serializable]
public class BGMAudioEntry
{
    [SerializeField]
    public AudioClip Clip;
    [SerializeField]
    public BGMAudioType AudioType;
}