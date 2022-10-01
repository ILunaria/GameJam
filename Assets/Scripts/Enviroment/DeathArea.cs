using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
    Collider _collider;
    ResetObjects reset;
    void Start()
    {
        reset = FindObjectOfType<ResetObjects>().GetComponent<ResetObjects>();
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject.GetComponent<GameObject>();
        if(collision.gameObject.tag == "Player")
        {
            Destroy(go);
            reset.OnDeath();
        }
    }
}
