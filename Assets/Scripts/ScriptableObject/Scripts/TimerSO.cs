using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TimerSO : ScriptableObject
{
    public float floatTimer;
    public int intTimer;

    public void TimerReset()
    {
        floatTimer = 0;
        intTimer = 0;
    }
}
