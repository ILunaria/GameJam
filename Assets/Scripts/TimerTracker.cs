using TMPro;
using UnityEngine;

public class TimerTracker : MonoBehaviour
{
    private float currentTime;

    private TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        updateTimer(currentTime);
    }
    void updateTimer(float current)
    {
        current += 1;

        float minutes = Mathf.FloorToInt(current / 60);
        float seconds = Mathf.FloorToInt(current % 60);

        textMesh.text = string.Format("{0:00} : {1:00} ", minutes, seconds);
    }
}
