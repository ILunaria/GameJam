using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Status", menuName = "Status/Player Status", order = 2)]
public class PlayerStatus : Status
{
    #region Weapon Status
    [Header("Weapon Status")]

    [Header("In Game Status")]
    public GameObject bullet;
    public float bulletSpeed;
    public float fireRate;

    [Header("Original Status")]
    [SerializeField] private float originBulletSpeed;
    [SerializeField] private float originFireRate;
    #endregion
    private void OnEnable()
    {
        OnPlayerReset();
    }
    public void OnPlayerReset()
    {
        maxHp = originMaxHp;
        moveSpeed = originMoveSpeed;
        damage = originDamage;
        bulletSpeed = originBulletSpeed;
        fireRate = originFireRate;
    }
}
