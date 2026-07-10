using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public PlayerMovement aria;
    public PlayerMovement shadow;

    private PlayerHealth playerHealth;
    private Rigidbody2D shadowRb;

    public bool lightOn = true;
    private bool canTakeDamage = true;

    void Start()
    {
        playerHealth = aria.GetComponent<PlayerHealth>();
        shadowRb = shadow.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!lightOn || !canTakeDamage)
            return;

        // فقط سایه در نور دشمن آسیب ببیند
        if (other.CompareTag("Shadow"))
        {
            canTakeDamage = false;

            AudioManager.Instance.PlayEnemy();

            if (playerHealth != null)
            {
                playerHealth.LoseLife(shadow.transform, shadowRb, true);
            }

            Invoke(nameof(ResetDamage), 0.5f);
        }
    }

    private void ResetDamage()
    {
        canTakeDamage = true;
    }
}