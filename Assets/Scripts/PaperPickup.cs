using UnityEngine;


// Class will inherit methods and properties from the Interactable class
// Parent class handles Start() 
public class PaperPickup : Interactable
{
    public PaperViewer paperViewer; // The panel that contains the paper object
    public string paperText; // The text component of the paper object
    public Sprite paperImage; // The image component of the paper object

    public NotebookManager notebookManagerObject; // The notebook manager object that manages the collected notes
    public string paperID; // The unique identifier for the paper object (used for notebook)

    protected override void OnMouseDown()
    {
        base.OnMouseDown(); // Call the base class's OnMouseDown method to show the interaction message

        // Show the paper panel with the text and image
        paperViewer.ShowPaper(paperText, paperImage);

        notebookManagerObject.AddNote(paperID, paperText);
        gameObject.SetActive(false); // Hide the paper object after it has been picked up
    }
}