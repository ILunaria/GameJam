using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{

    [SerializeField] private PlayerStatus _status;

    [Header("Status Upgrade in %")]
    [SerializeField] private float speedUpgrade;
    [SerializeField] private float fireRateUpgrade;
    [SerializeField] private int damageUpgrade;

    private float baseSpeed;
    private float baseFireRate;

    private void Awake()
    {
        baseSpeed = _status.moveSpeed;
        baseFireRate = _status.fireRate;
    }
    public void MoveSpeedUpgrade()
    {
        _status.moveSpeed += (baseSpeed * (speedUpgrade/100));
    }
    public void HpUpgrade()
    {
        _status.maxHp++;
        _status.currentHp++;
    }
    public void FireRateUpgrade()
    {
        _status.fireRate += (baseFireRate * (fireRateUpgrade/100));
    }
    public void DamageUpgrade()
    {
        _status.damage += damageUpgrade;
    }
}
