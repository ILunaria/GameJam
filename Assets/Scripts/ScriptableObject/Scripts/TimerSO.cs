using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TimerSO : ScriptableObject
{
    public float currentTime;

    private void OnEnable()
    {
        TimerReset();
    }
    public void TimerReset()
    {
        currentTime = 0;
    }
}
