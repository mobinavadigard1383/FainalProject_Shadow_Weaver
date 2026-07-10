using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public Transform checkpoint;
    public Transform aria;
    public Transform shadow;

    private Rigidbody2D ariaRb;
    private Rigidbody2D shadowRb;

    private PlayerHealth ariaHealth;

    void Start()
    {
        ariaRb = aria.GetComponent<Rigidbody2D>();
        shadowRb = shadow.GetComponent<Rigidbody2D>();

        ariaHealth = aria.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   Debug.Log(other.tag);
        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
        {
            // پخش صدای دشمن
            AudioManager.Instance.PlayEnemy();

            // کم شدن یک جان
            if (ariaHealth != null)
            {
                ariaHealth.LoseLife(aria, ariaRb, false);
            }

            // برگرداندن هر دو شخصیت به Checkpoint
            aria.position = checkpoint.position;
            shadow.position = checkpoint.position + new Vector3(1.5f, 0f, 0f);

            ariaRb.velocity = Vector2.zero;
            shadowRb.velocity = Vector2.zero;
        }
    }
}