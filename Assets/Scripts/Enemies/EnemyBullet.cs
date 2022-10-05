using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private EnemySO _status;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float colliderRange;
    private Player _player;
    private Rigidbody rb;
    private void Awake()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();

        rb = GetComponent<Rigidbody>();

    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * (_status.bulletSpeed * 10) * Time.fixedDeltaTime;
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(transform.position, colliderRange, playerLayer) && _player.canTakeDamage())
        {
            AttackDamage();
        }
        if (Physics.CheckSphere(transform.position, colliderRange, playerLayer) && _player.canTakeDamage() == false)
        {
            Destroy(gameObject);
        }
    }
    private void AttackDamage()
    {
        _player.TakeDamage(_status.damage);
    }
}
