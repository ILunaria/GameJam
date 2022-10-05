using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "Status/EnemyStatus", order = 1)]
public class EnemySO : Status
{
    [Header("Enemys Checks")]
    public bool canSpawn;
    public bool canShoot;

    private void OnEnable()
    {
        canSpawn = false;
    }
}
