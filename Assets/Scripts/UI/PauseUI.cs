using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    private PlayerInputs inputs;
    [SerializeField] private GameObject allGround;
    private List<GameObject> groundArray = new List<GameObject>();
    private GroundFall _fall;
    public bool isPaused;
    private void Awake()
    {
        isPaused = false;
        CountGround();
        inputs = new PlayerInputs();
        inputs.Player.Enable();
        inputs.Player.Pause.performed += OnPauseInput;
    }
    private void Start()
    {
        UnPauseGame();
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

        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void UnPauseGame()
    {
        isPaused = false;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
    private void OnFallGroundInput()
    {

        int maxItens = groundArray.Count - 1;

        if (maxItens > 0)
        {
            int item = Random.Range(0, maxItens);
            _fall = groundArray[item].GetComponent<GroundFall>();
            _fall.StartFall();
            groundArray.Remove(groundArray[item]);
        }
        else if(maxItens == 0)
        {
            _fall = groundArray[maxItens].GetComponent<GroundFall>();
            _fall.StartFall();
            groundArray.Remove(groundArray[maxItens]);
        }
        else return;
    }
    private void CountGround()
    {
        for (int i = 0; i < allGround.transform.childCount; i++)
        {
            groundArray.Add(allGround.transform.GetChild(i).gameObject);
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
