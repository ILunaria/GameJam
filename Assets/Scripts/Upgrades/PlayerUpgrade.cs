using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{

    [SerializeField] private PlayerStatus _status;
    [SerializeField] private float priceMultiplier;
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

    #region LEVEL STATUS VALOR
    private int speedLv;
    private int fireRateLv;
    private int hpLv;
    private int damageLv;
    #endregion
    private float baseSpeed;
    private float baseFireRate;

    private HpBar _hp;

    [Header("Sounds")]
    [SerializeField] private AudioCue hpSound;
    [SerializeField] private AudioCue speedSound;
    [SerializeField] private AudioCue fireRateSound;
    [SerializeField] private AudioCue multiShootSound;
    [SerializeField] private AudioCue damageSound;

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
            speedSound.PlayAudioCue();
            speedLv += 1;
        }
    }
    public void HpUpgrade()
    {
        _ui = GameObject.Find("CardHP").GetComponent<UpCardUI>();
        int price = _ui.GetPrice();
        if (_status.money < price) return;
        else if(hpLv < 13)
        {
            _status.maxHp += hp;
            _status.currentHp += hp;
            _status.money -= price;
            _ui.UpCard(priceMultiplier);
            _hp.ShowHp();
            hpSound.PlayAudioCue();
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
            fireRateSound.PlayAudioCue();
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
            damageSound.PlayAudioCue();
            damageLv += 1;
        }
    }
    public void BulletUpgrade()
    {
        _ui = GameObject.Find("CardBullets").GetComponent<UpCardUI>();
        int price = _ui.GetPrice();
        if (_status.money < price) return;
        else if (_status.bullets < 5)
        {
            _status.bullets += 1;
            _status.money -= price;
            _ui.UpCard(priceMultiplier);
            _hp.ShowHp();
            multiShootSound.PlayAudioCue();
            hpLv += 1;
        }
    }
}
