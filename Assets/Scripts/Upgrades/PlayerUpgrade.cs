using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{

    [SerializeField] private PlayerStatus _status;

    [Header("Status Upgrade in %")]
    [SerializeField] private float speedUpgrade;
    [SerializeField] private float fireRateUpgrade;

    private float baseSpeed;
    private float baseFireRate;

    private void Awake()
    {
        baseSpeed = _status.moveSpeed;
        baseFireRate = _status.fireRate;
    }
    public void MoreMoveSpeed()
    {
        _status.moveSpeed += (baseSpeed * (speedUpgrade/100));
    }
    public void LessMoveSpeed()
    {
        _status.moveSpeed -= (baseSpeed * (speedUpgrade / 100));
    }
    public void MoreFireRate()
    {
        _status.fireRate += (baseFireRate * (fireRateUpgrade/100));
    }
    public void LessFireRate()
    {
        _status.fireRate -= (fireRateUpgrade * (fireRateUpgrade / 100));
    }
}
