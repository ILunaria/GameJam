using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetObjects : MonoBehaviour
{
    [SerializeField] private PlayerStatus player;
    [SerializeField] private TimerSO timer;
    private void Start()
    {
        timer.TimerReset();
    }
    private void Update()
    {
        if (player.isPlayerDead) return;
        if(player.currentHp <= 0)
        {
            OnDeath();
            player.isPlayerDead = true;
        }
    }
    public void OnDeath()
    {
        StartCoroutine(Wait());
        timer.TimerReset();
        player.OnPlayerReset();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void OnQuit()
    {
        Application.Quit();
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(3f);
    }
}
