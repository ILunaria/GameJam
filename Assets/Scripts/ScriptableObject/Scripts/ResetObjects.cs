using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetObjects : MonoBehaviour
{
    [SerializeField] private PlayerStatus player;

    private void Update()
    {
        if(player.currentHp <= 0)
        {
            OnDeath();
        }
    }
    public void OnDeath()
    {
        player.OnPlayerReset();
        SceneManager.LoadScene(0);
    }
}
