using UnityEngine;

public class Reveal : Interactable
{
    public GameObject[] objectsToReveal; // The objects that will be revealed when the player clicks on the object
    public GameObject[] objectsToHide; // The objects that will be hidden when the player clicks on the object

    private bool isRevealed = false; // A flag to track whether the objects have been revealed or not

    protected override void OnMouseDown()
    {
        base.OnMouseDown(); // Call the base class's OnMouseDown method to show the interaction message

        if (isRevealed)
        {
            return; // If the objects have already been revealed, do nothing
        }

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
