using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Status _status;

    #region CHECK PARAMETERS
    //Set all of these up in the inspector
    [Header("Checks")]

    [SerializeField] private Transform enemyCheckPoint;
    [SerializeField] private float enemyCheckSize;
    #endregion

    #region LAYERS & TAGS
    [Header("Layers & Tags")]
    [SerializeField] private LayerMask enemyLayer;
    #endregion
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.CheckSphere(enemyCheckPoint.position, enemyCheckSize, enemyLayer) && _player.canTakeDamage())
        {
            AttackDamage();
        }
    } 
    private void AttackDamage()
    {
        _player.TakeDamage(_status.damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(enemyCheckPoint.position, enemyCheckSize);
    }
}
