using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPitchChanger : MonoBehaviour
{
    private AudioSource AudioSource;
    float newPitch = 3f;
    float oldPitch;
    public bool hasBoss;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        oldPitch = AudioSource.pitch;
    }
    private void Update()
    {
        if(hasBoss)
        {
            ChangePitch();
        }
        else
            BasePitch();
    }
    public void ChangePitch()
    {
        AudioSource.pitch = Mathf.Lerp(AudioSource.pitch, newPitch, Time.deltaTime);
    }
    public void BasePitch()
    {
        AudioSource.pitch = Mathf.Lerp(AudioSource.pitch, oldPitch, Time.deltaTime);
    }
}
