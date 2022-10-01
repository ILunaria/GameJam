using UnityEngine;

[CreateAssetMenu(fileName = "General Status", menuName = "Status/General Status", order = 1)]
public class Status : ScriptableObject
{
    public int MaxHp;
    public float MoveSpeed;
    public int Damage;
}
