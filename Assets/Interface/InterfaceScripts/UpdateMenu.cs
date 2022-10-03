using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMenu : MonoBehaviour
{
    public Canvas Up;   

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Up.gameObject.SetActive(!Up.gameObject.activeSelf);         
        }   
    }
}