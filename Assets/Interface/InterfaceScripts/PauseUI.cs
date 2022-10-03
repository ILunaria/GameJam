using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class PauseUI : MonoBehaviour
{
    private PlayerInputs inputs;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject allGround;
    private List<GameObject> ground = new List<GameObject>();
    private FallGround _fall;
    public static bool isPaused;
    private void Awake()
    {
        CountGround();
        isPaused = false;
        inputs = new PlayerInputs();
        inputs.Player.Enable();
        inputs.Player.Pause.performed += OnPauseInput;
    }
    private void OnPauseInput(InputAction.CallbackContext context)
    {
        if(context.performed && !isPaused)
        {
            PauseGame();
            OnFallGroundInput();
        }
        else if(context.performed && isPaused)
        {
            UnPauseGame();
        }
    }
    private void PauseGame()
    {
        isPaused = true;
        Cursor.visible = true;



        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void UnPauseGame()
    {
        isPaused = false;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    private void OnFallGroundInput()
    {

        int item = ground.Count - 1;

        if (item > 0)
        {
            _fall = ground[item].GetComponent<FallGround>();
            _fall.StartFall();
            ground.Remove(ground[item]);
        }
        else return;
    }
    private void CountGround()
    {
        for(int i = 0; i < allGround.transform.childCount; i++)
        {
            ground.Add(allGround.transform.GetChild(i).gameObject);
        }
    }
}
