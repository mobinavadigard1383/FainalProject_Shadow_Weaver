using UnityEngine;

public class FloatingKey : MonoBehaviour
{
    public float height = 0.5f;
    public float speed = 3f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos +
            Vector3.up * Mathf.Sin(Time.time * speed) * height;
    }
}