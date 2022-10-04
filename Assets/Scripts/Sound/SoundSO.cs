using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SoundSO : ScriptableObject
{
    [Header("Sounds")]

    public List<SoundAudioClip> _soundArray = new List<SoundAudioClip>();
    public static List<SoundAudioClip> soundArray = new List<SoundAudioClip>();

    [Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    private void OnValidate()
    {
        Debug.Log("Validate");
        soundArray = _soundArray;
    }
    private void OnEnable()
    {
        Debug.Log("Enable");
    }
    private void OnDisable()
    {
        Debug.Log("Disable");
    }
}
