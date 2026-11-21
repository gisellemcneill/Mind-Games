using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public TMP_Text characterName;
    public TMP_Text dialogueText;

    private string[] dialogueLines;
    private int currentLine = 0;

    public string gameplaySceneName;

    void Start() {
        dialogueLines = new string[] {
            "Where am I?",
            "This isn't the mall...",
            "The last thing I remember was meeting my friend at the mall...",
            "Then the power went off...",
            "I can't remember anything after that.",
            "What is this room?",
            "Some kind of Lecture Hall?"
        };
        DisplayLine();
    }

    public void AdvanceDialogue() {
        currentLine++;
        if (currentLine < dialogueLines.Length) {
            DisplayLine();
        } else {
            SceneManager.LoadScene(gameplaySceneName);
        }
    }

    void DisplayLine() {
        characterName.text = "Mika";
        dialogueText.text = dialogueLines[currentLine];
    }
}
