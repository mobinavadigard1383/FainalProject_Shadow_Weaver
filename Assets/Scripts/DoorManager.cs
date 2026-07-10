using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorManager : MonoBehaviour
{
    public DoorController door;

    private bool levelFinished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (levelFinished) return;

        if (other.CompareTag("Player"))
        {
            if (door == null)
            {
                Debug.LogError("DoorController is not assigned!");
                return;
            }

            if (door.isOpen)
            {
                levelFinished = true;
                StartCoroutine(LoadNextLevel());
            }
        }
    }

    IEnumerator LoadNextLevel()
    {
        // قطع موسیقی مرحله (اختیاری)
        if (AudioManager.Instance.musicSource != null)
            AudioManager.Instance.musicSource.Stop();

        // پخش صدای برد
        AudioManager.Instance.PlayVictory();

        // صبر برای تمام شدن صدا
        yield return new WaitForSeconds(3f);

        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.Log("🎉 Game Completed!");
        }
    }
}