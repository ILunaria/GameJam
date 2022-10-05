using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField] private PlayerStatus player;
    [SerializeField] private GameObject HpIcon;
    [SerializeField] private Transform content;
    private void Awake()
    {
        ShowHp();
    }
    public void ShowHp()
    {
        foreach (Transform t in content)
        {
            Destroy(t.gameObject);
        }
        for (int i = 0; i < player.currentHp; i++)
        {
            GameObject obj = Instantiate(HpIcon, content);
        }
    }
}
