using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float timer = 0f;
    private bool gamePaused = false;

    void Update()
    {
        if (!gamePaused)
        {
            timer += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);

            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        gamePaused = true;
    }
}