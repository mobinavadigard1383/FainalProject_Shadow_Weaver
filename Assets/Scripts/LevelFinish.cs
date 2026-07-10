using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelFinish : MonoBehaviour
{
    bool finished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (finished) return;

        if (other.CompareTag("Player"))
        {
            finished = true;

            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        // پخش صدای برد
        AudioManager.Instance.musicSource.Stop();
       
        AudioManager.Instance.PlayVictory();

        // صبر کن تا صدا پخش شود
        yield return new WaitForSeconds(2f);

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentScene + 1);
        }
        else
        {
            Debug.Log("Game Completed!");
        }
    }
}