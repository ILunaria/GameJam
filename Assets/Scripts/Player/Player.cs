using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status;
    [SerializeField] private float invulnerableTime = 0;

    [SerializeField] private SpriteRenderer render;

    private HpBar hp;
    private float invulnerableTimer = 0;
    private float timer = 0;
    private void Awake()
    {
        hp = FindObjectOfType<HpBar>().GetComponent<HpBar>();
    }
    private void Update()
    {
        invulnerableTimer -= Time.deltaTime;
        if(timer <= 0)
        {
            render.color = Color.white;
        }

        else timer -= Time.deltaTime;

        if(_status.currentHp <= 0)
        {
            PlayerDeath.OnPlayerDeath();
        }
    }
    public void TakeDamage(int damage)
    {
        SoundManager.PlaySound(SoundManager.Sound.PlayerDamage);
        invulnerableTimer = invulnerableTime;
        _status.currentHp -= damage;
        render.color = Color.red;
        timer = 1f;
        hp.ShowHp();

    }
    public bool canTakeDamage()
    {
        if (invulnerableTimer <= 0)
        {
            return true;
        }
        else return false;
    }
    public void GetEXP(int valor)
    {
        _status.money += valor;
    }
}
