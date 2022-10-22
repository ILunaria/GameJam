using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPDrop : MonoBehaviour
{
    private Rigidbody rb;
    private Transform target;
    private Player player;
    [SerializeField] private float moveSpeed;
    Vector3 moveDirection;

    [Header("Checks")]

    [SerializeField] private Transform dropCheckPoint;
    [SerializeField] private float dropCheckSize;

    #region LAYERS & TAGS
    [Header("Layers & Tags")]
    [SerializeField] private LayerMask dropLayer;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("PlayerRoot").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        moveDirection = direction;
    }
    private void FixedUpdate()
    {
        if (Physics.CheckSphere(dropCheckPoint.position, dropCheckSize, dropLayer))
        {
            SoundManager.PlaySound(SoundManager.Sound.CollectableSound02,transform.position);
            rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z) * moveSpeed * Time.fixedDeltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player = other.gameObject.GetComponent<Player>();
            player.GetEXP();
            SoundManager.PlaySound(SoundManager.Sound.CollectableSound01);
            gameObject.SetActive(false);
            Destroy(gameObject,1f);
        }
    }

}
