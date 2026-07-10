using UnityEngine;

public class EndingDialogue : MonoBehaviour
{
    public GameObject victoryText;

    private bool finished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (finished) return;

        if (other.CompareTag("Player"))
        {
            finished = true;

            Debug.Log("Player Reached Dad");

            victoryText.SetActive(true);

            AudioManager.Instance.PlayVictory();
        }
    }
}