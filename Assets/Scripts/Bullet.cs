using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private PlayerStatus status;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * status.bulletSpeed, ForceMode.Impulse);
        SoundManager.PlaySound(SoundManager.Sound.PlayerAttack,transform.position);
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
