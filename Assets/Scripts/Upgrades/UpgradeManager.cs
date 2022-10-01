using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private Status _status;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoreMoveSpeed()
    {
        _status.MoveSpeed += 1;
    }
    public void LessMoveSpeed()
    {
        _status.MoveSpeed -= 1;
    }
}
