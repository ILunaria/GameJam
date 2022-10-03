using UnityEngine;
using UnityEngine.InputSystem;

public class PauseUI : MonoBehaviour
{
    private PlayerInputs inputs;
    [SerializeField] private GameObject pauseMenu;
    public static bool isPaused;
    private void Awake()
    {
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
}
