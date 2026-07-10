using UnityEngine;

public class AriaKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PuzzleManager.Instance.ariaKey = true;
            gameObject.SetActive(false);
            PuzzleManager.Instance.CheckPuzzle();
        }
    }

  
}