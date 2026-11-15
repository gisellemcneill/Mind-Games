using UnityEngine;

public class Interactable : MonoBehaviour
{
    // The message that appears when the object is clicked
    public string interactionMessage;

    // The highlight object
    public GameObject highlight;

    // The dialogue manager
    public DialogueManager dialogueManager;

    void Start() {
        highlight.SetActive(false);
    }

    void OnMouseEnter() {
        highlight.SetActive(true); // When the mouse hovers over the object, show the highlight
    }

    void OnMouseExit() {
        highlight.SetActive(false); // When the mouse stops hovering over the object, hide the highlight
    }

    // protected and virtual were added to allow inheritance and overriding
    // protected allows the method to be accessed by derived classes, 
    // while virtual allows derived classes to override the method's behavior
    protected virtual void OnMouseDown() {

        if(interactionMessage != null || interactionMessage != ""){
            dialogueManager.ShowDialogue(interactionMessage); // Displays the message on the dialogue box
        }  
    }
}
