using UnityEngine.SceneManagement;
public static class PlayerDeath
{
    public static void OnPlayerDeath()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
