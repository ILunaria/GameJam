using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCueHolder : MonoBehaviour
{
    [SerializeField] private AudioCue groundUp;
    [SerializeField] private AudioCue groundDown;

    public void PlayGroundUp()
    {
        groundUp.PlayAudioCue();
    }
    public void PlayGroundDown()
    {
        groundDown.PlayAudioCue();
    }
}
