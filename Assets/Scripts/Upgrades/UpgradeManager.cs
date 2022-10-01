using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status;
    public void MoreMoveSpeed()
    {
        _status.moveSpeed += 1;
    }
    public void LessMoveSpeed()
    {
        _status.moveSpeed -= 1;
    }
}
