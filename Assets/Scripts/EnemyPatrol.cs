using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speed = 2f;

    private Transform target;

    void Start()
    {
        target = pointB;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 targetPos = new Vector3(
            target.position.x,
            transform.position.y,
            transform.position.z);

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - target.position.x) < 0.05f)
        {
            if (target == pointA)
            {
                target = pointB;
                transform.localScale = new Vector3(0.4f, 0.4f, 1);
            }
            else
            {
                target = pointA;
                transform.localScale = new Vector3(-0.4f, 0.4f, 1);
            }
        }
    }
}