using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Status", menuName = "Status/Player Status", order = 2)]
public class PlayerStatus : Status
{
    public float playerGravity;
    [NonSerialized] public bool isPlayerDead;
    [NonSerialized] public int currentHp;
    public int money;
    #region Weapon Status
    [Header("Weapon Status")]

    [Header("In Game Status")]
    public GameObject bullet;
    public float bulletSpeed;
    public float fireRate;
    public int bullets;

    [Header("Original Status")]
    [SerializeField] private float originBulletSpeed;
    [SerializeField] private float originFireRate;
    private int originMoney = 0;
    #endregion
    private void OnEnable()
    {
        OnPlayerReset();
        Debug.Log("Enable");
    }
    private void OnDisable()
    {
        Debug.Log("Disable");
    }
    public void OnPlayerReset()
    {
        maxHp = originMaxHp;
        currentHp = originMaxHp;
        moveSpeed = originMoveSpeed;
        damage = originDamage;
        bulletSpeed = originBulletSpeed;
        fireRate = originFireRate;
        money = originMoney;
        isPlayerDead = false;
        bullets = 1;
    }
}
