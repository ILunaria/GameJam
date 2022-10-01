using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Status _status;
    // Start is called before the first frame update
    void Start()
    {
        _status = (Status)ScriptableObject.CreateInstance(typeof(Status));
        Debug.Log(_status.moveSpeed);
        ScriptableObject.Destroy(_status, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
