using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Status _status;
    private int currentHp;
    private Rigidbody rb;
    private Transform target;
    private Vector3 moveDirection;
    private bool isDead = false;

    private CapsuleCollider capsuleC;
    EnemyAttack attack;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = _status.maxHp;
        rb = GetComponent<Rigidbody>();
        attack = GetComponent<EnemyAttack>();
        capsuleC = GetComponent<CapsuleCollider>();
        target = GameObject.Find("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        // Get Direction
        Vector3 direction = (target.position - transform.position).normalized;
        moveDirection = direction;
    }
    private void FixedUpdate()
    {
        if(!isDead)
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z) * _status.moveSpeed * Time.fixedDeltaTime;
    }
    public void TakeDamage(int Damage)
    {
        currentHp -= Damage;

        if (currentHp <= 0) Death();

        else StartCoroutine(ChangeColor(0.2f));
    }
    IEnumerator ChangeColor(float time)
    {

        spriteRenderer.color = Color.white;

        yield return new WaitForSeconds(time);

        spriteRenderer.color = Color.red;
    }
    private void Death()
    {
        isDead = true;
        
        attack.SetCanAttack(isDead);
        spriteRenderer.color = Color.green;
        rb.velocity = Vector3.zero;
        capsuleC.enabled = false;
        Destroy(gameObject, 3f);
    }
}
