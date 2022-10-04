using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
    [SerializeField] private PlayerStatus status;
    Collider _collider;
    void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject go = collision.gameObject.GetComponent<GameObject>();
        if (collision.gameObject.tag == "Player")
        {
            status.currentHp = 0;
        }
    }
}
