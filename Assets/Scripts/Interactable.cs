using UnityEngine;

public class Interactable : MonoBehaviour
{
    // The message that appears when the object is clicked
    public string interactionMessage;

    public Sprite speakerPicture;

    // The highlight object
    public GameObject highlight;

    // The dialogue manager
    public DialogueManager dialogueManager;

    void Start() {
        highlight.SetActive(false);
    }

    void OnMouseEnter() {
       
       if (OpeningScene.isPlaying)
        {
            return;
        }
       
       highlight.SetActive(true); // When the mouse hovers over the object, show the highlight
    }

    void OnMouseExit() {
        highlight.SetActive(false); // When the mouse stops hovering over the object, hide the highlight
    }

    // protected and virtual were added to allow inheritance and overriding
    // protected allows the method to be accessed by derived classes, 
    // while virtual allows derived classes to override the method's behavior
    protected virtual void OnMouseDown() {

        if (OpeningScene.isPlaying)
        {
            return;
        }

        if(interactionMessage != null || interactionMessage != ""){
            dialogueManager.ShowDialogue(interactionMessage, speakerPicture); // Displays the message on the dialogue box
        }  
    }
}
