using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Status _status;
    private Rigidbody rb;
    private Transform target;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(_status.moveSpeed);
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
        rb.velocity = new Vector3 (moveDirection.x, 0, moveDirection.z) * _status.moveSpeed * Time.fixedDeltaTime;
    }
}
