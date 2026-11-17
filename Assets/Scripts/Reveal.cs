using UnityEngine;

public class Reveal : Interactable
{
    public GameObject[] objectsToReveal; // The objects that will be revealed when the player clicks on the object
    public GameObject[] objectsToHide; // The objects that will be hidden when the player clicks on the object

    public string revealID; // The unique identifier for this reveal action, used for JSON saving and loading

    // Used read only property, anyone can see this variable but only this class can modify it (JSON)
    public bool isRevealed {get; private set;} = false; // A flag to track whether the objects have been revealed or not

    protected override void OnMouseDown()
    {
        base.OnMouseDown(); // Call the base class's OnMouseDown method to show the interaction message

        if (isRevealed)
        {
            return; // If the objects have already been revealed, do nothing
        }

        DoReveal(); // Call the method to reveal the objects
    }

    // Moved the reveal logic so that SaveManager can restore the room without showing 
    // the dialog box. This is important for loading the game state correctly. 
    public void DoReveal()
    {
        foreach (GameObject obj in objectsToReveal)
        {
            if(obj == null) continue; // Skip if the object is null

            obj.SetActive(true);
        }

        foreach (GameObject obj in objectsToHide)
        {
            if(obj == null) continue; // Skip if the object is null
            
            obj.SetActive(false);
        }

        isRevealed = true; // Set the flag to true to indicate that the objects have been revealed  
    }
}
