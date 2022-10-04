using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private PlayerInputs inputs;
    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void Jogar()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1,LoadSceneMode.Single);
    }

    public void Sair()
    {
        Debug.Log("Saiu!");
        Application.Quit();
    }
}
