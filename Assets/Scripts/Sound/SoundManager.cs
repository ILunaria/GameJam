using System.Collections.Generic;
using UnityEngine;
using static SoundSO;

public static class SoundManager
{
    public enum Sound
    {
        PlayerMove,
        PlayerAttack,
        PlayerDamage,
        EnemyDamage,
    }
    private static Dictionary<Sound, float> soundTimerDictionary;
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;

    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerMove] = 0f;
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
            audio.Play();
            Object.Destroy(soundGO, audio.clip.length);
        }
    }
    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default: return true;
            case Sound.PlayerMove:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float maxTimer = 0.3f;
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
