using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetObjects : MonoBehaviour
{
    [SerializeField] private PlayerStatus player;

    public void OnDeath()
    {
        player.OnReset();
        SceneManager.LoadScene(0);
    }
}
