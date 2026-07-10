using UnityEngine;

public class LightButton : MonoBehaviour
{
    public EnemyVision enemyVision;
    public GameObject flashLight;

    private bool pressed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (pressed)
            return;

        if (other.CompareTag("Player"))
        {
            pressed = true;

            // خاموش شدن نور
            flashLight.SetActive(false);

            // دشمن دیگر نمی‌بیند
            enemyVision.lightOn = false;
        }
    }
}