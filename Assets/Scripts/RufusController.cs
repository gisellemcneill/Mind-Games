using UnityEngine;

public class RufusController : Interactable
{
    public string[] hints; // The hints that Rufus gives the player
    public Transform[] possibleLocations; // The possible locations that Rufus can move to

    private int currentHint = 0; // Tracks the current hint that Rufus is giving
    private int nextLocation = 0; // Tracks the next location that Rufus will go to

    protected override void OnMouseDown() {
        // If Rufus has wisdom to give, display the wisdom
        if (currentHint < hints.Length) {
            dialogueManager.ShowDialogue(hints[currentHint], speakerPicture);
            currentHint++;
        } else {
            dialogueManager.ShowDialogue("Meow?", speakerPicture); // Rufus ran out of hints
        }
        MoveRufus();
    }

    private void MoveRufus() {
        if (possibleLocations.Length == 0) {
            return;
        }
        transform.position = possibleLocations[nextLocation].position; // Move Rufus
        nextLocation++;
        // If Rufus reached the end of his possible locations, reset back to the beginning location
        if (nextLocation >= possibleLocations.Length) {
            nextLocation = 0;
        }
    }
}
