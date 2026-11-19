using UnityEngine;
using TMPro;

public class KeyPadUI : MonoBehaviour
{

    public GameObject keypadPanel; // The panel that contains the keypad UI

    public AudioManager audioManager; //Reference to AudioManager script

    public TMP_Text displayText; // The text component that displays the entered code

    public GameObject[] doorUnlockedHideObjects; // The objects that will be hidden when the correct code is entered

    public GameObject[] doorUnlockedShowObjects; // The objects that will be shown when the correct code is entered

    [SerializeField] private string correctCode; // The correct code to unlock the keypad

    private string enteredCode = ""; // The code that the player has entered

    //Used read only property, anyone can see this variable but only this class can modify it (JSON)
    public bool doorUnlocked {get; private set;} = false; // A flag to track whether the door has been unlocked or not

    private int failedAttempts = 0; // Tracks the number of times the player failed to enter the correct code

    private const int MAX_ATTEMPTS = 3; // The max number of attempts the player has to enter the incorrect code

    private bool gameOver = false; // Tracks whether the game is over

    public GameObject gameOverPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keypadPanel.SetActive(false); // Hide the keypad panel at the start
        gameOverPanel.SetActive(false); // Hide the game over panel
    }

    // Open the keypad panel and display the entered code
    public void Open()
    {

        if(doorUnlocked)
        {
            return; // If the door has already been unlocked, do nothing
        }

        keypadPanel.SetActive(true); // Show the keypad panel

        displayText.text = enteredCode; // Update the display text with the entered code

    }

    // Close the keypad panel
    public void Close()
    {
        keypadPanel.SetActive(false); // Hide the keypad panel
    }

    // Add the entered digit to the result and check if the entered code matches the correct code
    public void enterDigit(string digit)
    {
        if(doorUnlocked || gameOver)
        {
            return; // If the door has already been unlocked or the game is over, do nothing
        }

        enteredCode += digit; // Add the entered digit to the code

        displayText.text = enteredCode; // Update the display text with the entered code

        if(enteredCode.Length == correctCode.Length)
        {
            checkCode();
        }

    }

    public void checkCode()
    {
        if(enteredCode == correctCode)
        {
            unlockDoor();
        }
        else
        {
            failedAttempts++;
            // If the player ran out of attempts to guess the code, end the game
            if (failedAttempts >= MAX_ATTEMPTS) {
                TriggerGameOver();
            }
            displayText.text = "WRONG"; // Update the display text with the entered code
            enteredCode = ""; // Clear the entered code
        }
    }

    private void TriggerGameOver() {
        gameOver = true;
        keypadPanel.SetActive(false); // Hide the keypad panel
        gameOverPanel.SetActive(true); // Show the game over panel
    }

    public void unlockDoor()
    {
        doorUnlocked = true; // Set the flag to true to indicate that the door has been unlocked

        audioManager.PlayWin();
        displayText.text = "CORRECT"; // Update the display text with the unlocked message


        foreach (GameObject obj in doorUnlockedHideObjects)
        {
            if(obj == null) continue; // Skip if the object is null

            obj.SetActive(false); // Hide the objects that should be hidden when the door is unlocked
        }

        foreach (GameObject obj in doorUnlockedShowObjects)
        {
            if(obj == null) continue; // Skip if the object is null

            obj.SetActive(true); // Show the objects that should be shown when the door is unlocked
        }

    }

    public void Clear()
    {
        enteredCode = ""; // Clear the entered code

        displayText.text = enteredCode; // Update the display text with the entered code
    }

}
