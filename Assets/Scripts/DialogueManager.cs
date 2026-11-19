using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;

    public Image characterPictureLocation; 
    public Sprite defaultPicture; //Mika
    public TMP_Text dialogueText;

    void Awake()
    {
        dialogueBox.SetActive(false);
    }

    // Displays a message in the dialogue box
    //picture set as null so already existing uses of this method
    // will use the default image instead of us having to go back
    public void ShowDialogue(string message, Sprite picture = null) {
        dialogueText.text = message;
        SetPicture(picture);
        dialogueBox.SetActive(true);
    }

    // Closes the dialogue box
    public void CloseDialogue() {
        dialogueBox.SetActive(false);
    }

    public void SetPicture(Sprite picture)
    {
        if(picture != null)
        {
            characterPictureLocation.sprite = picture;
        }
        else
        {
            characterPictureLocation.sprite = defaultPicture;
        }
    }
}
