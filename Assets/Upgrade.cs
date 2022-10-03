using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Canvas Up;
    public GameObject chao;
    

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Up.gameObject.SetActive(!Up.gameObject.activeSelf);         
        }   
    }
}
