using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemySO _status;
    [SerializeField] private GameObject _weapon;

    #region CHECK PARAMETERS
    //Set all of these up in the inspector
    [Header("Checks")]

    [SerializeField] private Transform enemyCheckPoint;
    [SerializeField] private float enemyCheckSize;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private LayerMask playerLayer;
    #endregion

    #region LAYERS & TAGS
    [Header("Layers & Tags")]
    #endregion
    private Player _player;
    private bool canAttack = true;

    private float timeSinceLastShoot;
    private Vector3 worldPosition;
    private Vector3 aimDirection;

    private float currentFireRate;
    private int currentDamage;
    private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();
        currentDamage = _status.damage;
        currentFireRate = _status.fireRate;
        if(_status.isRanged)
        {
            if (_status.level >= 10)
            {
                bullet = _status.bullet03;
            }
            if (_status.level >= 5 && _status.level < 10)
            {
                bullet = _status.bullet02;
            }
            else bullet = _status.bullet01;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_status.isRanged)
        {

            timeSinceLastShoot += Time.deltaTime;

            worldPosition = _player.transform.position;
            worldPosition.y = transform.position.y;

            aimDirection = Vector3.Normalize(worldPosition - transform.position);
            _weapon.transform.forward = Vector3.Lerp(transform.forward, aimDirection, 20f * Time.deltaTime);

            if (Physics.CheckSphere(enemyCheckPoint.position, _status.attackRange, playerLayer))
            {
                _status.canShoot = true;
                Shoot();
            }
            else _status.canShoot = false;
        }
        else
        {
            if(Physics.CheckSphere(enemyCheckPoint.position, enemyCheckSize, playerLayer) && _player.canTakeDamage() && canAttack)
            {
                AttackDamage();
            }
        }
    } 
    private void AttackDamage()
    {
        _player.TakeDamage(currentDamage);
    }

    public void SetCanAttack(bool isdead)
    {
        if(isdead)
        {
            canAttack = false;
        }
    }
    private bool EnemyCanShoot() => timeSinceLastShoot > 1f / (currentFireRate / 60);
    private void Shoot()
    {
        if(EnemyCanShoot())
        {
            Instantiate(bullet, bulletSpawn.position, Quaternion.LookRotation(aimDirection, Vector3.up));

            timeSinceLastShoot = 0f;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(enemyCheckPoint.position,_status.attackRange);
        Gizmos.DrawSphere(enemyCheckPoint.position, enemyCheckSize);
    }
}
