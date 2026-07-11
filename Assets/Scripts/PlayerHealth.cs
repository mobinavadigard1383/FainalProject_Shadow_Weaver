using UnityEngine;
using UnityEngine.SceneManagement;
 

public class PlayerHealth : MonoBehaviour
{    
    public int maxLives = 3;
    private int currentLives;

    public Transform respawnPoint;
    public Animator animator;
    public UIHealth uiHealth;

    private PlayerMovement movement;
    private Rigidbody2D rb;

    void Start()
{
    currentLives = maxLives;

    movement = GetComponent<PlayerMovement>();
    rb = GetComponent<Rigidbody2D>();

    if (uiHealth != null)
        uiHealth.UpdateHearts(currentLives);
}
private bool takingDamage = false;

public void LoseLife(Transform player, Rigidbody2D playerRb, bool respawnPlayer = true)
{
    if (takingDamage)
        return;

    takingDamage = true;

    currentLives--;

    if (uiHealth != null)
        uiHealth.UpdateHearts(currentLives);

    Debug.Log("Lives: " + currentLives);

    if (currentLives > 0)
    {
        if (respawnPlayer)
        {
            playerRb.velocity = Vector2.zero;
            player.position = respawnPoint.position;
        }
    }
    else
    {
        Die();
    }

    Invoke(nameof(ResetDamage), 0.3f);
}

private void ResetDamage()
{
    takingDamage = false;
}

    void Respawn()
    {
        rb.velocity = Vector2.zero;
        transform.position = respawnPoint.position;
    }
     
     public int GetCurrentLives()
{
    return currentLives;
}
    void Die()
    {
        movement.canControl = false;
        rb.velocity = Vector2.zero;

       Debug.Log("GAME OVER");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}