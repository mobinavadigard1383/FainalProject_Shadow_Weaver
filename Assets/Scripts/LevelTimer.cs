using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float levelTime = 60f;
    public TextMeshProUGUI timerText;

    private float currentTime;
    private bool isPaused = false;

    void Start()
    {    Debug.Log("LevelTimer Start");
        Time.timeScale = 1f;   // زمان بازی را ریست کن
    AudioListener.pause = false;
          
        currentTime = levelTime;
    }

    void Update()
{     Debug.Log(Time.timeScale);
    if (!isPaused)
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    int minutes = Mathf.FloorToInt(currentTime / 60);
    int seconds = Mathf.FloorToInt(currentTime % 60);

    timerText.text = $"{minutes:00}:{seconds:00}";
}

   public void PauseGame()
{
    Debug.Log("Pause Clicked");
    Time.timeScale = 0f;
    isPaused = true;
     AudioListener.pause = true;
}

public void PlayGame()
{
    Debug.Log("Play Clicked");
    Time.timeScale = 1f;
    isPaused = false;
    AudioListener.pause = false;
}
}