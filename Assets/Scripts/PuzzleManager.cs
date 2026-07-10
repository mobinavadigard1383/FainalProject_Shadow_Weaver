using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public bool ariaKey = false;
    public bool shadowKey = false;

    public DoorController door;

    private void Awake()
    {
        Instance = this;
    }
public void CheckPuzzle()
{
  
    if (ariaKey && shadowKey)
    {
        door.OpenDoor();
    }

}
}