using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

 public void UpdateHearts(int lives)
{
    Debug.Log("UpdateHearts Called");
    Debug.Log("Lives = " + lives);

    for (int i = 0; i < hearts.Length; i++)
{
    if (i < lives)
    {
        hearts[i].sprite = fullHeart;
        hearts[i].color = Color.white;
    }
    else
    {
        hearts[i].sprite = emptyHeart;
        hearts[i].color = Color.gray;
    }
}
}
}