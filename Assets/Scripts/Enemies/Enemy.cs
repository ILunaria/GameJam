using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Status _status;
    [SerializeField] private GameObject drop;
    private int currentHp;
    private Rigidbody rb;
    private Transform target;
    private Vector3 moveDirection;
    private bool isDead = false;

    private SphereCollider checkCollider;
    EnemyAttack attack;
    public SpriteRenderer spriteRenderer;
    private Color baseColor;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = _status.maxHp;
        rb = GetComponent<Rigidbody>();
        attack = GetComponent<EnemyAttack>();
        checkCollider = GetComponent<SphereCollider>();
        target = GameObject.Find("Player").transform;
        baseColor = spriteRenderer.color;
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

        spriteRenderer.color = baseColor;
    }
    private void Death()
    {

        isDead = true;
        Instantiate(drop, transform.position, Quaternion.identity);
        attack.SetCanAttack(isDead);
        rb.velocity = Vector3.zero;
        checkCollider.enabled = false;
        Destroy(gameObject);
    }
}
