using UnityEngine;
using System.Collections.Generic;
using System.IO;

// A class to store the data that will be saved and loaded in JSON format
[System.Serializable]
public class SaveData
{
    public List<string> collectedNotesJSON = new List<string>(); // A list to store the collected notes
    public List<string> collectedNoteIDsJSON = new List<string>(); // A list to store the unique identifiers of the collected notes
    public List<string> collectedNoteTitlesJSON = new List<string>(); // A list to store the titles of the collected notes

    public bool doorUnlocked; // A boolean to store the state of the door (locked/unlocked)
    public RoomNavigation.Side currentSide; // The current side of the room that the player is on
    public List<string> revealIDs = new List<string>(); // A list to store whcih reveals have happened in the room

}

// A class to manage saving and loading the game state
public class SaveManager : MonoBehaviour
{
    public NotebookManager notebookManager; // A reference to the NotebookManager script
    public KeyPadUI keyPadUI; // A reference to the KeyPadUI script
    public RoomNavigation roomNavigation; // A reference to the RoomNavigation script
    public List<Reveal> reveals; // A list of all the Reveals that have happened in the room
    public List<PaperPickup> paperPickedUp = new List<PaperPickup>(); // A list to store the papers that have been picked up by the player

    private string saveFilePath; // The path to the save file

    void Start()
    {
        saveFilePath = Application.persistentDataPath + "/savegame.json"; // Set the path to the save file
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData(); // Create a new instance of the SaveData class

        // Save the collected notes, note IDs, and note titles from the NotebookManager
        saveData.collectedNotesJSON = notebookManager.collectedNotes;
        saveData.collectedNoteIDsJSON = notebookManager.collectedNoteIDs;
        saveData.collectedNoteTitlesJSON = notebookManager.collectedNoteTitles;

        // Save the state of the door from the KeyPadUI
        saveData.doorUnlocked = keyPadUI.doorUnlocked;

        // Save the current side of the room from the RoomNavigation
        saveData.currentSide = roomNavigation.currentSide;

        // Save the revealIDs from the Reveal scripts
        foreach (Reveal reveal in reveals)
        {
            if (reveal.isRevealed)
            {
                saveData.revealIDs.Add(reveal.revealID);
            }
        }

        // Convert the SaveData object to a JSON string
        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(saveFilePath, json); // Write the JSON string to the save file

        Debug.Log("Game saved to " + saveFilePath); // Log a message to the console indicating that the game has been saved

    }

    public void LoadGame()
    {

        if(!File.Exists(saveFilePath))
        {
            Debug.LogWarning("Save file not found at " + saveFilePath);
            return; // If the save file does not exist, do nothing
        }

        // Convert the JSON string back to a SaveData object
        SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveFilePath));

        notebookManager.LoadNotes(saveData.collectedNotesJSON, saveData.collectedNoteIDsJSON, saveData.collectedNoteTitlesJSON); // Load the collected notes, note IDs, and note titles into the NotebookManager

        // Load the state of the door into the KeyPadUI
        if(saveData.doorUnlocked)
        {
            keyPadUI.unlockDoor(); // Call the unlockDoor method to unlock the door;
        }

        // Load the current side of the room into the RoomNavigation
        roomNavigation.setSide(saveData.currentSide); // Call the setSide method to set the current side of the room

        // Load the revealIDs into the Reveal scripts
        foreach (Reveal reveal in reveals)
        {
            if (saveData.revealIDs.Contains(reveal.revealID)) {
                reveal.DoReveal(); // Call the DoReveal method to reveal the objects
            }
        }

        foreach (PaperPickup paper in paperPickedUp)
        {
            if (saveData.collectedNoteIDsJSON.Contains(paper.paperID)) {
                paper.HidePaper(); // Call the HidePaper method to hide the note
            }
        }
    }
}
