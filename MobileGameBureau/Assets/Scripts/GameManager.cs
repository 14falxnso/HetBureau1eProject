using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

    private float elapsedTime;
    private int lastDisplayedSecond = -1;

    public bool IsPlaying => Time.timeScale > 0f;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        int seconds = (int)elapsedTime;

        if (seconds != lastDisplayedSecond)
        {
            lastDisplayedSecond = seconds;
            timerText.text = $"{seconds / 60}:{seconds % 60:00}";
        }
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}