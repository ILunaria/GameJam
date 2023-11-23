using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderEffectController : MonoBehaviour
{
    public AudioMixerGroup audioMixerGroup;
    public Slider slider;

    private string volumePlayerPrefsKey = "SFXVolume";

    void Start()
    {
        SetVolume(slider.value);
    }

    void Awake()
    {
        slider.onValueChanged.AddListener(SetVolume);

        float savedVolume = PlayerPrefs.GetFloat(volumePlayerPrefsKey, slider.value);
        slider.value = savedVolume;
        SetVolume(savedVolume);
    }

    void SetVolume(float volume)
    {
        audioMixerGroup.audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(volumePlayerPrefsKey, volume);
        PlayerPrefs.Save();
    }
    
}
