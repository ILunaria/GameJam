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

    [Header("Original Status")]
    [SerializeField] private float originBulletSpeed;
    #endregion
    private void OnEnable()
    {
        OnReset();
    }
    public void OnReset()
    {
        maxHp = originMaxHp;
        moveSpeed = originMoveSpeed;
        damage = originDamage;
        bulletSpeed = originBulletSpeed;
    }
}
