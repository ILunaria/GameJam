using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EXPDrop : MonoBehaviour
{
    [SerializeField] private int expValor;
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
        target = GameObject.Find("Player").transform;
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
            rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z) * moveSpeed * Time.fixedDeltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player = other.gameObject.GetComponent<Player>();
            player.GetEXP(expValor);
            Destroy(gameObject);
        }
    }

}
