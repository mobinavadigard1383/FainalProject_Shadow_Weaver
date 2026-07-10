using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public PlayerMovement aria;

    private PlayerHealth playerHealth;
    private Rigidbody2D ariaRb;

    private bool canTakeDamage = true;

    void Start()
    {
        playerHealth = aria.GetComponent<PlayerHealth>();
        ariaRb = aria.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canTakeDamage)
            return;

        if (collision.gameObject.CompareTag("Player"))
        {
            canTakeDamage = false;

            AudioManager.Instance.PlayEnemy();

            if (playerHealth != null)
            {
                // فقط یک جان کم شود و آریا همانجا بماند
                playerHealth.LoseLife(aria.transform, ariaRb, false);
            }

            // بعد از 2 ثانیه دوباره بتواند آسیب ببیند
            Invoke(nameof(ResetDamage), 2f);
        }
    }

    private void ResetDamage()
    {
        canTakeDamage = true;
    }
}