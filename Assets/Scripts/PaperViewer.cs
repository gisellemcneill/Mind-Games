using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PaperViewer : MonoBehaviour
{
    public GameObject paperPanel; // The panel that contains the paper object

    public Image paperImage; // The image component of the paper object 

    private Sprite blankPaper; // Base image of the paper object, used to reset the paper image when no image is provided
    public TMP_Text paperText; // The text component of the paper object    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blankPaper = paperImage.sprite; // Store the base image of the paper object
        paperPanel.SetActive(false); // Hide the paper panel at the start
    
    }
    // Displays the paper with the given text and image
    public void ShowPaper(string text, Sprite image)
    {
        if(image != null)
        {
            paperImage.sprite = image;
        }
        else
        {
            paperImage.sprite = blankPaper; // Reset the paper image to the base image if no image is provided
        }

        paperText.text = text; // Set the paper text
        paperPanel.SetActive(true); // Show the paper panel
    }

    // Hides the paper object
    public void HidePaper()
    {
        paperPanel.SetActive(false);
    }

}
