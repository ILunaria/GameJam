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
        timer.floatTimer += Time.deltaTime;
        timer.intTimer = Mathf.FloorToInt(timer.floatTimer);
        if(player.currentHp <= 0)
        {
            OnDeath();
            player.isPlayerDead = true;
        }
    }
    public void OnDeath()
    {
        SoundManager.PlaySound(SoundManager.Sound.PlayerDeath);
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
