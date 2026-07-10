using UnityEngine;

public class MirrorWorld : MonoBehaviour
{
    public GameObject bridge;
    public GameObject enemy;

    public Camera mainCamera;

    private bool mirror = false;

    private void OnTriggerEnter2D(Collider2D other)
    {

        AudioManager.Instance.PlayMirror();
        if (!other.CompareTag("Player") &&
            !other.CompareTag("Shadow"))
            return;

        mirror = !mirror;

        if (mirror)
        {
            bridge.SetActive(true);
            enemy.SetActive(false);

            if (mainCamera != null)
                mainCamera.backgroundColor = Color.white;
        }
        else
        {
            bridge.SetActive(false);
            enemy.SetActive(true);

            if (mainCamera != null)
                mainCamera.backgroundColor = new Color(0.3f, 0.3f, 0.6f);
        }
    }
}