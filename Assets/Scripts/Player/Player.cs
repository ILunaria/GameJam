using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status;

    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private float invulnerableTime = 0;

    private float invulnerableTimer = 0;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        _status.currentHp = _status.maxHp;
    }
    private void Update()
    {
        invulnerableTimer -= Time.deltaTime;
        if(timer <= 0)
        {
            spr.color = Color.white;
        }

        else timer -= Time.deltaTime;
    }
    public void TakeDamage(int damage)
    {
        invulnerableTimer = invulnerableTime;
        _status.currentHp -= damage;
        spr.color = Color.blue;
        timer = 1f;

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
