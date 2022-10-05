using UnityEngine;

public class Status : ScriptableObject
{
    #region Generic Status

    [Header("In Game Status")]
    public int maxHp;
    public float moveSpeed;
    public int damage;

    [Header("Original Status")]
    [SerializeField] protected int originMaxHp;
    [SerializeField] protected float originMoveSpeed;
    [SerializeField] protected int originDamage;
    #endregion
    private void OnEnable()
    {
        OnReset();
    }
    public void OnReset()
    {
        maxHp = originMaxHp;
        moveSpeed = originMoveSpeed;
        damage = originDamage;
    }
}
