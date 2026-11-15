using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    // The 4 sides of the Lecture Hall room
    public enum Side {
        Front,
        Right,
        Back,
        Left
    }

    public Side currentSide = Side.Front; // The side of the room that the player is currently on

    public GameObject front;
    public GameObject right;
    public GameObject back;
    public GameObject left;

    void Start() {
        ShowCurrentSide();
    }

    // Shows the side that the player is currently on
    void ShowCurrentSide() {
        front.SetActive(currentSide == Side.Front);
        right.SetActive(currentSide == Side.Right);
        back.SetActive(currentSide == Side.Back);
        left.SetActive(currentSide == Side.Left);
    }

    // Switches to the next side of the room
    public void NextSide() {
        currentSide = (Side) (((int) currentSide + 1) % 4);
        ShowCurrentSide();
    }

    // Switches to the previous side of the room
    public void PreviousSide() {
        currentSide = (Side) (((int) currentSide + 3) % 4);
        ShowCurrentSide();
    }
}
