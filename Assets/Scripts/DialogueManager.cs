using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text dialogueText;

    void Start() {
        dialogueBox.SetActive(false);
    }

    // Displays a message in the dialogue box
    public void ShowDialogue(string message) {
        dialogueText.text = message;
        dialogueBox.SetActive(true);
    }

    // Closes the dialogue box
    public void CloseDialogue() {
        dialogueBox.SetActive(false);
    }
}
