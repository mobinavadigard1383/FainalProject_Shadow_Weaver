using UnityEngine;

public class ShadowKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Shadow"))
        {
            PuzzleManager.Instance.shadowKey = true;
            gameObject.SetActive(false);
            PuzzleManager.Instance.CheckPuzzle();
        }
    }

   
}