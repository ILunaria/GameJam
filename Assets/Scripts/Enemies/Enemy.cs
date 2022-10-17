using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySO _status;
    [SerializeField] private GameObject drop;
    [SerializeField] private Transform rotate;
    [SerializeField] private SpriteRenderer spriteRender;

    private SoundPitchChanger _pitchChanger;
    private int currentHp;
    private Rigidbody rb;
    private Transform target;

    private Vector3 moveDirection;
    private bool isDead = false;
    private float currentSpeed;
    private SphereCollider checkCollider;
    EnemyAttack attack;
    private Color baseColor;
    // Start is called before the first frame update
    void Start()
    {
        if(_status.level >= 10)
        {
            spriteRender.sprite = _status.sprite03;
        }
        else if(_status.level >= 5 && _status.level < 10)
        {
            spriteRender.sprite = _status.sprite02;
        }
        else
        {
            spriteRender.sprite = _status.sprite01;
        }
        currentSpeed = _status.moveSpeed;
        _pitchChanger = FindObjectOfType<SoundPitchChanger>().GetComponent<SoundPitchChanger>();
        if(_status.isBoss)
        {
            _pitchChanger.hasBoss = true;
        }
        transform.position = new Vector3(transform.position.x, 0.7f, transform.position.z);
        currentHp = _status.maxHp;
        rb = GetComponent<Rigidbody>();
        attack = GetComponent<EnemyAttack>();
        checkCollider = GetComponent<SphereCollider>();
        target = GameObject.Find("PlayerRoot").transform;
        baseColor = spriteRender.color;
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 0.9)
        {
            transform.position = new Vector3(Random.Range(-20,20), 0.7f, Random.Range(-20,20));
        }
        // Get Direction
        Vector3 direction = Vector3.Normalize(target.position - transform.position);
        moveDirection = direction;

        EnemyRotation();
    }
    private void FixedUpdate()
    {
        if(!isDead)
        {
            if(_status.canShoot)
            {
                rb.velocity = Vector3.zero;
            }
            else
            {
                rb.velocity = new Vector3(moveDirection.x, 0, moveDirection.z) * currentSpeed * Time.fixedDeltaTime;
            }
        }
    }
    public void TakeDamage(int Damage)
    {
        currentHp -= Damage;

        if (currentHp <= 0) Death();

        else StartCoroutine(ChangeColor(0.2f));
    }
    IEnumerator ChangeColor(float time)
    {

        spriteRender.color = Color.red;

        yield return new WaitForSeconds(time);

        spriteRender.color = baseColor;
    }
    private void Death()
    {
        if(_status.isBoss)
        {
            _status.damage = _status.damage * 2;
            _status.maxHp = _status.maxHp * 2;
            _status.moveSpeed = _status.moveSpeed * 1.2f;
            _pitchChanger.hasBoss = false;
        }
        isDead = true;
        attack.SetCanAttack(isDead);
        rb.velocity = Vector3.zero;
        checkCollider.enabled = false;
        for(int i = 0; i <= _status.level; i++)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    private void EnemyRotation()
    {
        if (moveDirection.x < 0)
        {
            var rotation = Quaternion.Euler(0, 180f, 0f);
            rotate.localRotation = Quaternion.Lerp(rotate.localRotation, rotation, 20f * Time.fixedDeltaTime);
        }
        else if (moveDirection.x > 0)
        {
            var rotation = Quaternion.Euler(0, 0, 0);
            rotate.localRotation = Quaternion.Lerp(rotate.localRotation, rotation, 20f * Time.fixedDeltaTime);
        }
    }
}
