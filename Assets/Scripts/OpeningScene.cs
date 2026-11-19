using NUnit.Framework.Constraints;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string text;
    public Sprite picture;
}

public class OpeningScene : MonoBehaviour
{
    public DialogueManager dialogueManager; //reference to DialogueManager

    public GameObject openingSceneButton; //reference to the button covering dialogue box
    
    private int currentLine; //acts as an iterator to store index
    public bool introSeen {get; private set;} = false; 

    public static bool isPlaying;
    
    [SerializeField] DialogueLine[] introLines;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        ShowLines();  
    }

    public void ShowLines()
    {

        currentLine = 0; 
        isPlaying = true;
        dialogueManager.dialogueBox.SetActive(true);
        openingSceneButton.SetActive(true);
        dialogueManager.dialogueText.text = introLines[currentLine].text;
        dialogueManager.SetPicture(introLines[currentLine].picture);
    }

    public void NextLine()
    {

        currentLine++;

        if(currentLine < introLines.Length)
        {
            dialogueManager.dialogueText.text = introLines[currentLine].text;
            dialogueManager.SetPicture(introLines[currentLine].picture);


        }else{

        dialogueManager.dialogueBox.SetActive(false);
        openingSceneButton.SetActive(false);
        introSeen = true;
        isPlaying = false;

        }

    }

    public void SkipIntro()
    {
        introSeen = true;
        isPlaying = false;
        dialogueManager.dialogueBox.SetActive(false);
        openingSceneButton.SetActive(false);

    }

}
