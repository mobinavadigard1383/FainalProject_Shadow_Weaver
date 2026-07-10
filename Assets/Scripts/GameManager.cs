using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMovement aria;
    public PlayerMovement shadow;
    public AudioSource audioSource;
public AudioClip switchSound;

    public CameraFollow cameraFollow;

    public float maxSwapDistance = 20f;

    bool isShadowMode = false;

    void Start()
{
    Physics2D.IgnoreLayerCollision(
        LayerMask.NameToLayer("Shadow"),
        LayerMask.NameToLayer("ShadowWall"),
        true);

    aria.canControl = true;
    shadow.canControl = false;

    cameraFollow.player = aria.transform;
}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {    
        AudioManager.Instance.PlaySwitch();
            SwitchControl();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SwapCharacters();
        }
    }

    void SwitchControl()
    {
        isShadowMode = !isShadowMode;

        if (isShadowMode)
        {
            aria.canControl = false;
            shadow.canControl = true;

            cameraFollow.player = shadow.transform;
        }
        else
        {
            aria.canControl = true;
            shadow.canControl = false;

            cameraFollow.player = aria.transform;
        }
    }
void SwapCharacters()
{
    if (!isShadowMode)
        return;

    Rigidbody2D ariaRb = aria.GetComponent<Rigidbody2D>();
    Rigidbody2D shadowRb = shadow.GetComponent<Rigidbody2D>();

    // توقف حرکت
    ariaRb.velocity = Vector2.zero;
    shadowRb.velocity = Vector2.zero;

    // جابجایی
    Vector3 tempPos = aria.transform.position;
    aria.transform.position = shadow.transform.position;
    shadow.transform.position = tempPos;

    // کنترل دوباره روی آریا
    aria.canControl = true;
    shadow.canControl = false;

    cameraFollow.player = aria.transform;

    isShadowMode = false;
}
}