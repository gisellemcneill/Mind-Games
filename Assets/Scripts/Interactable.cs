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

    void OnMouseDown() {
        dialogueManager.ShowDialogue(interactionMessage); // Displays the message on the dialogue box
    }
}
