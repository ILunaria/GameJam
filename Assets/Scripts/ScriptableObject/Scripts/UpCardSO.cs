using System;
using UnityEngine;

[CreateAssetMenu]
public class UpCardSO : ScriptableObject
{
    public int level;
    public string upName;
    [NonSerialized] public int price;
    public string upDescription;
    public Sprite icon;

    [Header("")]
    [SerializeField]private int startPrice;

    private void OnEnable()
    {
        level = 0;
        price = startPrice;
    }
}
