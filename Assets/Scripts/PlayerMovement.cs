using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpForce = 15f;
    public AudioSource audioSource;
public AudioClip jumpSound;

    public bool canControl = true;

    private Rigidbody2D rb;
    private bool isGrounded;

    private MovingPlatform currentPlatform;

    private Vector3 startScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.interpolation = RigidbodyInterpolation2D.Interpolate;

        startScale = transform.localScale;
    }

    void Update()
    {
        if (!canControl)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        float move = Input.GetAxisRaw("Horizontal");

        float platformVelocity = 0f;

        if (currentPlatform != null)
            platformVelocity = currentPlatform.Velocity.x;

        rb.velocity = new Vector2(
            move * moveSpeed + platformVelocity,
            rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
          {
    rb.velocity = new Vector2(
        rb.velocity.x,
        jumpForce);

    AudioManager.Instance.PlayJump();
            }

        if (move > 0)
        {
            transform.localScale = new Vector3(
                -Mathf.Abs(startScale.x),
                startScale.y,
                startScale.z);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(startScale.x),
                startScale.y,
                startScale.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            isGrounded = true;

            currentPlatform =
                collision.gameObject.GetComponent<MovingPlatform>();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("MovingPlatform"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            currentPlatform = null;
            isGrounded = false;
        }
    }
}