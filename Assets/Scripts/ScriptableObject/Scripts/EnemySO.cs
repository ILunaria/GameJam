using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "Status/EnemyStatus", order = 1)]
public class EnemySO : Status
{
    [Header("Enemys Checks")]
    public bool canSpawn;
    public bool isRanged;

    [Header("Reanged Options")]
    public bool canShoot;
    public float attackRange;
    public float fireRate;
    public GameObject bullet;
    public float bulletSpeed;

    private void OnEnable()
    {
        canSpawn = false;
        OnReset();
    }

    public void OnReset()
    {
        maxHp = originMaxHp;
        moveSpeed = originMoveSpeed;
        damage = originDamage;
    }
}
