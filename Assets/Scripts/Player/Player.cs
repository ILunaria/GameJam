using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status;
    [SerializeField] private float invulnerableTime = 0;
    PlayerAudioCuesHolder playerAudios;

    private int expValue = 5;
    [SerializeField] float timeToMoreExp;
    private float expTime;

    private Animator animator;
    private HpBar hp;
    private float invulnerableTimer = 0;
    private void Awake()
    {
        _status.OnPlayerReset();
        animator = GetComponent<Animator>();
        hp = FindObjectOfType<HpBar>().GetComponent<HpBar>();hp.ShowHp();
        playerAudios = GetComponent<PlayerAudioCuesHolder>();
    }
    private void Update()
    {
        invulnerableTimer -= Time.deltaTime;
        expTime -= Time.deltaTime;
        if(expTime < 0)
        {
            expValue += 5;
            expTime = timeToMoreExp;
        }

        if(_status.currentHp <= 0)
        {
            invulnerableTime = 3f;
            animator.SetBool("isDead", true);
        }
    }
    public void TakeDamage(int damage)
    {
        playerAudios.PlayDamage();
        invulnerableTimer = invulnerableTime;
        _status.currentHp -= damage;
        hp.ShowHp();
        animator.SetTrigger("TakeDamage");
    }
    public bool canTakeDamage()
    {
        if (invulnerableTimer <= 0)
        {
            return true;
        }
        else return false;
    }
    public void GetEXP()
    {
        playerAudios.PlayExp();
        _status.money += expValue;
    }
    public void Death()
    {
        gameObject.SetActive(false);
        PlayerDeath.OnPlayerDeath();
    }
}
