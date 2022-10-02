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
        timer.floatTimer += Time.deltaTime;
        timer.intTimer = Mathf.FloorToInt(timer.floatTimer);
        if(player.currentHp <= 0)
        {
            OnDeath();
        }
    }
    public void OnDeath()
    {
        timer.TimerReset();
        player.OnPlayerReset();
        SceneManager.LoadScene(0);
    }
}
