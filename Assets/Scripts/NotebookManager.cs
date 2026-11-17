using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class NotebookManager : MonoBehaviour
{
    public GameObject notebookPanel; // The notebook panel that displays the collected notes
    public TMP_Text notebookText; // The text component of the notebook panel that displays the collected notes
    public TMP_Text pageCounterText; // The text component of the notebook panel that displays the page counter
    public TMP_Text noteTitle; // The text component of the notebook panel that displays the title of the note
    
    public List<string> collectedNotes = new List<string>(); // A list to store the collected notes
    public List<string> collectedNoteIDs = new List<string>(); // A list to store the unique identifiers of the collected notes
    public List<string> collectedNoteTitles = new List<string>(); // A list to store the titles of the collected notes
    private int currentPage; // The current page index of the notebook

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        notebookPanel.SetActive(false); // Hide the notebook panel at the start
    }

    public void Open()
    {
        notebookPanel.SetActive(true); // Show the notebook panel
        ShowCurrentNote();
    }

    public void Close()
    {
        notebookPanel.SetActive(false); // Hide the notebook panel
    }

    public void AddNote(string id, string noteText, string noteTitle)
    {
        if (!collectedNoteIDs.Contains(id))
        {
            collectedNotes.Add(noteText);
            collectedNoteIDs.Add(id);
            collectedNoteTitles.Add(noteTitle);
            currentPage = collectedNotes.Count - 1; // Set the current page index to the last added note
            ShowCurrentNote(); // Show the newly added note
        }
    }

    public bool HasNote(string id)
    {
        return collectedNoteIDs.Contains(id);
    }

    public void LoadNotes(List<string> notes, List<string> noteIDs, List<string> noteTitles)
    {
        collectedNotes = notes;
        collectedNoteIDs = noteIDs;
        collectedNoteTitles = noteTitles;
        currentPage = 0; // Reset the current page index to the first note
        ShowCurrentNote(); // Show the first note
    }

    public void ShowCurrentNote()
    {
        if(collectedNotes.Count == 0)
        {
            notebookText.text = "No notes collected."; // Display a message if no notes have been collected
            noteTitle.text = ""; // Clear the note title
            pageCounterText.text = ""; // Clear the page counter text
        }
        else
        {
            notebookText.text = collectedNotes[currentPage]; // Display the current note
            noteTitle.text = collectedNoteTitles[currentPage]; // Display the title of the current note
            pageCounterText.text = (currentPage + 1) + "/" + collectedNotes.Count; // Update the page counter text
        }
    }

    public void NextNote()
    {
        if (currentPage < collectedNotes.Count - 1)
        {
            currentPage++;
            ShowCurrentNote(); // Show the next note
        }else
        {
            currentPage = 0; // Loop back to the first note if at the end
            ShowCurrentNote(); // Show the first note
        }
    }

    public void previousNote()
    {
        if (currentPage > 0)
        {
            currentPage--;
            ShowCurrentNote(); // Show the previous note
        }else
        {
            currentPage = collectedNotes.Count - 1; // Loop back to the last note if at the beginning
            ShowCurrentNote(); // Show the last note
        }
    }

}
