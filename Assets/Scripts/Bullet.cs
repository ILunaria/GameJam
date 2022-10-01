using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private PlayerStatus status;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * (status.bulletSpeed * 10) * Time.fixedDeltaTime;
        Destroy(gameObject, 10f);
    }
}
