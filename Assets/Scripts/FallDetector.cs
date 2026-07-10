using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public Transform aria;

    private PlayerHealth playerHealth;


void Start()
{
    playerHealth = FindObjectOfType<PlayerHealth>();
}

private void OnTriggerEnter2D(Collider2D other)
{
   if (other.CompareTag("Player"))
{
    AudioManager.Instance.PlayFall();

    PlayerHealth health = FindObjectOfType<PlayerHealth>();

    if (health != null)
    {
        health.LoseLife(other.transform, other.GetComponent<Rigidbody2D>());
    }
}
else if (other.CompareTag("Shadow"))
{
    AudioManager.Instance.PlayFall();

   PlayerHealth health = FindObjectOfType<PlayerHealth>();

if (health != null)
{
    Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
    health.LoseLife(other.transform, rb);
}
}
}
}