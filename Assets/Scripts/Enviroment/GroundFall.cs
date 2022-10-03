using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFall : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartFall()
    {
        Debug.Log(gameObject.name + " est? caindo");
        Destroy(gameObject);
    }
}
