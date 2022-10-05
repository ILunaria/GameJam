using UnityEngine;
using UnityEngine.SceneManagement;
public static class PlayerDeath
{
    public static void OnPlayerDeath()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
