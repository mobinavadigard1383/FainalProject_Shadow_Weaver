using UnityEngine;

public class MirrorButton : MonoBehaviour
{
    public MirrorManager mirrorManager;

    private bool playerInside = false;

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {   AudioManager.Instance.PlayMirror();
            mirrorManager.SwitchWorld();
        }
    }
void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player") || other.CompareTag("Shadow"))
        playerInside = true;
}

void OnTriggerExit2D(Collider2D other)
{
    if (other.CompareTag("Player") || other.CompareTag("Shadow"))
        playerInside = false;
}
}