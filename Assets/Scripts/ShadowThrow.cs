using UnityEngine;

public class ShadowThrow : MonoBehaviour
{
    [Header("References")]
    public GameObject aimArrow;
    public Transform landingPoint;
    public Transform launchPoint;

    public float distance = 0.5f;

    [Header("Jump Settings")]
    public float jumpHeight = 2f;
    public float jumpTime = 0.6f;

    private PlayerMovement player;

    private bool isAiming = false;
    private bool isJumping = false;

    private Vector3 startPos;
    private float timer;

    void Start()
    {
        player = GetComponent<PlayerMovement>();

        if (aimArrow != null)
            aimArrow.SetActive(false);
    }

    void Update()
    {
        // فقط وقتی کنترل روی Shadow است
        if (!player.canControl)
            return;

        // شروع نشانه گیری
        if (Input.GetKeyDown(KeyCode.G) && !isJumping)
        {
            isAiming = true;

            if (aimArrow != null)
                aimArrow.SetActive(true);
        }

        // چرخش فلش
        if (isAiming)
        {
            RotateArrow();
        }

        // پرتاب
        if (Input.GetKeyUp(KeyCode.G) && isAiming)
        {
            isAiming = false;

            if (aimArrow != null)
                aimArrow.SetActive(false);

            StartJump();
        }

        // حرکت پرشی
        if (isJumping)
        {
            timer += Time.deltaTime;

            float t = timer / jumpTime;

            Vector3 pos = Vector3.Lerp(startPos, landingPoint.position, t);

            pos.y += Mathf.Sin(t * Mathf.PI) * jumpHeight;

            transform.position = pos;

            if (t >= 1f)
            {
                transform.position = landingPoint.position;

                isJumping = false;
            }
        }
    }

    void RotateArrow()
    {
        Vector3 mouse =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouse.z = 0;

        Vector2 dir =
            mouse - transform.position;

        float angle =
            Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        aimArrow.transform.rotation =
            Quaternion.Euler(0, 0, angle);
    }

    void StartJump()
    {
        startPos = transform.position;

        timer = 0;

        isJumping = true;
    }
}