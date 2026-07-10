using UnityEngine;

public class MirrorManager : MonoBehaviour
{
    [Header("Objects")]
    public GameObject bridge;
    public GameObject enemy;

    [Header("Camera")]
    public Camera mainCamera;

    public Color lightWorldColor = Color.white;
    public Color darkWorldColor = new Color(0.45f, 0.35f, 0.8f);

    [Header("Effects")]
    public ParticleSystem mirrorEffect;
    public AudioSource mirrorSound;

    private bool mirrorOn = false;

    void Start()
    {
        bridge.SetActive(false);
        enemy.SetActive(true);

        if (mainCamera != null)
            mainCamera.backgroundColor = lightWorldColor;
    }

    public void SwitchWorld()
    {
        mirrorOn = !mirrorOn;

        bridge.SetActive(mirrorOn);
        enemy.SetActive(!mirrorOn);

        if (mainCamera != null)
        {
            if (mirrorOn)
                mainCamera.backgroundColor = darkWorldColor;
            else
                mainCamera.backgroundColor = lightWorldColor;
        }

        if (mirrorEffect != null)
            mirrorEffect.Play();

        if (mirrorSound != null)
            mirrorSound.Play();
    }
}