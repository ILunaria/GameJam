using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioCuesHolder : MonoBehaviour
{
    #region DAMGE SOUND
    [SerializeField] private AudioCue damageSound;
    [SerializeField] private float damageSoundTimer;
    private float lastDamageSound;
    private bool canPlayDamageSound;
    #endregion
    #region STEP SOUND
    [SerializeField] private AudioCue stepSound;
    [SerializeField] private float stepSoundTimer;
    private float lastStepSound;
    private bool canPlayStepSound;
    #endregion
    #region SHOOT SOUND
    [SerializeField] private AudioCue attackSound;
    [SerializeField] private float shootSoundTimer;
    private float lastShootSound;
    private bool canPlayShootSound;
    #endregion
    #region SHOOT SOUND
    [SerializeField] private AudioCue expSound;
    [SerializeField] private float expSoundTimer;
    [SerializeField] private float lastExpSound;
    [SerializeField]private bool canPlayExpSound;
    #endregion
    private void Update()
    {
        lastStepSound += Time.deltaTime;
        lastShootSound += Time.deltaTime;
        lastDamageSound += Time.deltaTime;
        lastExpSound += Time.deltaTime;

        if(lastStepSound > stepSoundTimer)
        {
            canPlayStepSound = true;
        }
        else canPlayStepSound = false;

        if(lastShootSound > shootSoundTimer)
        {
            canPlayShootSound = true;
        }
        else canPlayShootSound = false;

        if (lastDamageSound > damageSoundTimer)
        {
            canPlayDamageSound = true;
        }
        else canPlayDamageSound = false;
        if (lastExpSound > expSoundTimer)
        {
            canPlayExpSound = true;
        }
        else canPlayExpSound = false;
    }
    public void PlayStep()
    {
        if(canPlayStepSound)
        {
            stepSound.PlayAudioCue();
            lastStepSound = 0;
        }
    }
    public void PlayShoot()
    {
        if (canPlayShootSound)
        {
            attackSound.PlayAudioCue();
            lastShootSound = 0;
        }
    }
    public void PlayDamage()
    {
        if(canPlayDamageSound)
        {
            damageSound.PlayAudioCue();
            lastDamageSound = 0;
        }
    }
    public void PlayExp()
    {
        if (canPlayExpSound)
        {
            expSound.PlayAudioCue();
            lastExpSound = 0;
        }
    }
}
