using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    

    private Rigidbody2D rb;
    private Vector2 target;
    private Vector2 lastPosition;

    public Vector2 Velocity { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;

        transform.position = pointA.position;

        target = pointB.position;

        lastPosition = rb.position;
    }

    void FixedUpdate()
    {
        Vector2 nextPosition = Vector2.MoveTowards(
            rb.position,
            target,
            speed * Time.fixedDeltaTime);

        Velocity = (nextPosition - lastPosition) / Time.fixedDeltaTime;

        rb.MovePosition(nextPosition);

        lastPosition = nextPosition;

        if (Vector2.Distance(nextPosition, target) < 0.02f)
        {
            if (target == (Vector2)pointA.position)
                target = pointB.position;
            else
                target = pointA.position;
        }
    }
}