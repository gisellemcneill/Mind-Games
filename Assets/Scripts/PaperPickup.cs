using UnityEngine;


// Class will inherit methods and properties from the Interactable class
// Parent class handles Start() 
public class PaperPickup : Interactable
{
    public PaperViewer paperViewer; // The panel that contains the paper object
    public string paperText; // The text component of the paper object
    public Sprite paperImage; // The image component of the paper object

    protected override void OnMouseDown()
    {
        base.OnMouseDown(); // Call the base class's OnMouseDown method to show the interaction message

        // Show the paper panel with the text and image
        paperViewer.ShowPaper(paperText, paperImage);
    }
}