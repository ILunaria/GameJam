using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private PlayerStatus status;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        SoundManager.PlaySound(SoundManager.Sound.PlayerAttack,transform.position);
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * (status.bulletSpeed * 10) * Time.fixedDeltaTime;
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(status.damage);
            Destroy(gameObject);
        }
    }
}
