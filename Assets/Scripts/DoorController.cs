using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Sprite closedDoor;
    public Sprite openDoor;

    private SpriteRenderer sr;

    public bool isOpen = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closedDoor;
    }

    public void OpenDoor()
    {
        isOpen = true;
        sr.sprite = openDoor;
    }
}