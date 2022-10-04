using System.Collections.Generic;
using UnityEngine;
using static SoundSO;

public static class SoundManager
{
    public enum Sound
    {
        PlayerMove01,
        PlayerMove02,
        PlayerMove03,
        PlayerMove04,
        PlayerAttack,
        PlayerDamage,
        PlayerDeath,
        EnemyDamage,
        EnemySound,
        CollectableSound01,
        CollectableSound02,
    }
    private static Dictionary<Sound, float> soundTimerDictionary;
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;

    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerMove01] = 0.6f;
        soundTimerDictionary[Sound.PlayerMove02] = 0.4f;
        soundTimerDictionary[Sound.PlayerMove03] = 0.2f;
        soundTimerDictionary[Sound.PlayerMove04] = 0.0f;
        soundTimerDictionary[Sound.EnemySound] = 0f;
        soundTimerDictionary[Sound.CollectableSound02] = 1f;
    }
    public static void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            if (oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("One Shot Sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            }
            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
        }
    }
    public static void PlaySound(Sound sound, Vector3 position)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGO = new GameObject("Sound");
            soundGO.transform.position = position;
            AudioSource audio = soundGO.AddComponent<AudioSource>();
            audio.clip = GetAudioClip(sound);
            audio.volume = 0.5f;
            audio.maxDistance = 20f;
            audio.spatialBlend = 1f;
            audio.rolloffMode = AudioRolloffMode.Linear;
            audio.dopplerLevel = 0f;
            audio.Play();
            Object.Destroy(soundGO, audio.clip.length);
        }
    }
    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default: return true;
            case Sound.PlayerMove01:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float maxTimer = 0.6f;
                    if (lastTimePlayed + maxTimer < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            case Sound.PlayerMove02:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float maxTimer = 0.6f;
                    if (lastTimePlayed + maxTimer < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            case Sound.PlayerMove03:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float maxTimer = 0.6f;
                    if (lastTimePlayed + maxTimer < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            case Sound.PlayerMove04:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float maxTimer = 0.6f;
                    if (lastTimePlayed + maxTimer < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            case Sound.CollectableSound02:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float maxTimer = 1f;
                    if (lastTimePlayed + maxTimer < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            case Sound.EnemySound:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float maxTimer = 2f;
                    if (lastTimePlayed + maxTimer < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
        }

    }
    private static AudioClip GetAudioClip(Sound sound)
    {
        //SoundSO.SoundAudioClip soundAudioClip in SoundSO.soundArray
        foreach (SoundSO.SoundAudioClip soundAudioClip in SoundSO.soundArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found");
        return null;
    }
}
