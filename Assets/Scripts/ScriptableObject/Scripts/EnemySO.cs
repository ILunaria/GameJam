using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "Status/EnemyStatus", order = 1)]
public class EnemySO : Status
{
    [Header("Level")]
    public int level;

    [Header ("Sprites")]
    public Sprite sprite01;
    public Sprite sprite02;
    public Sprite sprite03;

    [Header("Enemys Checks")]
    public bool isRanged;

    [Header("Reanged Options")]
    public bool canShoot;
    public float attackRange;
    public float fireRate;
    public GameObject bullet01;
    public GameObject bullet02;
    public GameObject bullet03;
    public float bulletSpeed;

    [Header("Boss Settings")]
    public bool isBoss;
    private void OnEnable()
    {
        OnReset();
    }

    public void OnReset()
    {
        maxHp = originMaxHp;
        moveSpeed = originMoveSpeed;
        damage = originDamage;
        level = 0;
    }
}
