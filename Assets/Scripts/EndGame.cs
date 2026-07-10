using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    public AudioSource gameMusic;

    public PlayerMovement aria;
    public PlayerMovement shadow;


    private bool finished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {   Debug.Log("EndGame Triggered by: " + other.name);
        if (finished)
            return;

        if (other.CompareTag("Player"))
        {
            finished = true;

            // قطع شدن موزیک
            gameMusic.Stop();

            // توقف کنترل بازیکن
            aria.canControl = false;
            shadow.canControl = false;

          

            // توقف زمان بازی
            Time.timeScale = 0f;
        }
    }
}