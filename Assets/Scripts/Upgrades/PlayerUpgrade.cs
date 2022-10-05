using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{

    [SerializeField] private PlayerStatus _status;
    [SerializeField] private int priceMultiplier;
    private UpCardUI _ui;

    [Header("Status Upgrade in %")]
    [SerializeField] private float speedUpgrade;
    [SerializeField] private float fireRateUpgrade;

    [Header("Status Upgrade in total value")]
    [SerializeField] private int damageUpgrade;
    [SerializeField] private int hp;

    [Header("Max Upgrades")]
    [SerializeField] private int maxSpeedLv;
    [SerializeField] private int maxFireRateLv;
    [SerializeField] private int maxDamageLv;
    [SerializeField] private int maxHpLv;

    #region LEVEL STATUS VALOR
    private int speedLv;
    private int fireRateLv;
    private int hpLv;
    private int damageLv;
    #endregion
    private float baseSpeed;
    private float baseFireRate;

    private HpBar _hp;

    private void Awake()
    {
        _hp = FindObjectOfType<HpBar>().GetComponent<HpBar>();
        baseSpeed = _status.moveSpeed;
        baseFireRate = _status.fireRate;
    }
    public void MoveSpeedUpgrade()
    {
        _ui = GameObject.Find("CardSpeed").GetComponent<UpCardUI>();
        int price = _ui.GetPrice();
        if (_status.money < price) return;
        else if(speedLv < maxSpeedLv)
        {
            _status.fireRate += baseSpeed * (speedUpgrade / 100);
            _status.money -= price;
            _ui.UpCard(priceMultiplier);

            speedLv += 1;
        }
    }
    public void HpUpgrade()
    {
        _ui = GameObject.Find("CardHP").GetComponent<UpCardUI>();
        int price = _ui.GetPrice();
        if (_status.money < price) return;
        else if(hpLv < maxHpLv)
        {
            _status.maxHp += hp;
            _status.currentHp += hp;
            _status.money -= price;
            _ui.UpCard(priceMultiplier);
            _hp.ShowHp();
            hpLv += 1;
        }
    }
    public void FireRateUpgrade()
    {
        _ui = GameObject.Find("CardFireRate").GetComponent<UpCardUI>();
        int price = _ui.GetPrice();
        if (_status.money < price) return;
        else if(fireRateLv < maxFireRateLv)
        {
            _status.fireRate += baseFireRate * (fireRateUpgrade / 100);
            _status.money -= price;
            _ui.UpCard(priceMultiplier);

            fireRateLv += 1;
        }
    }
    public void DamageUpgrade()
    {
        _ui = GameObject.Find("CardDamage").GetComponent<UpCardUI>();
        int price = _ui.GetPrice();
        if (_status.money < price)
        {
            return;
        }
        else if(damageLv < maxDamageLv)
        {
            _status.damage += damageUpgrade;
            _status.money -= price;
            _ui.UpCard(priceMultiplier);

            damageLv += 1;
        }
    }
}
