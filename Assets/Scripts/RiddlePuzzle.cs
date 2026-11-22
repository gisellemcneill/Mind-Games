using UnityEngine;

public class RiddlePuzzle : MonoBehaviour
{
    private int currentStage = 0; // Tracks the current stage of the puzzle
    public GameObject[] strangerSprites; // The sprites of the stranger
    public InventoryItem[] puzzleItems; // The items required to solve the puzzle
    public InventoryManager inventoryManager;
    public DialogueManager dialogueManager;
    public GameObject gameOverScreen;
    private bool gameOver = false;
    public GameObject gameWinScreen;
    public GameObject highlight;

    // Dialogue responses for each correct item
    [TextArea(2, 4)]
    public string[] dialogueResponses;

    void Start() {
        for (int i = 0; i < strangerSprites.Length; i++) {
            strangerSprites[i].SetActive(i == 0);
        }
    }

    public void TryUseItem() {
        // Check if the game is over or the puzzle is already finished
        if (gameOver || currentStage >= puzzleItems.Length) {
            return;
        }
        InventoryItem selected = inventoryManager.selectedItem;
        // Check if the player selected an item
        if (selected == null) {
            return;
        }
        // Check if the selected item is correct
        if (selected.itemName == puzzleItems[currentStage].itemName) {
            dialogueManager.ShowDialogue(dialogueResponses[currentStage]); // Display the response
            inventoryManager.RemoveItem(selected); // Remove the used item from the inventory
            currentStage++; // Go to the next stage
            // Update the Stranger's sprite
            int spriteIndex = Mathf.Min(currentStage, strangerSprites.Length - 1);
            for (int i = 0; i < strangerSprites.Length; i++) {
                strangerSprites[i].SetActive(i == spriteIndex);
            }
            // Check if the player completed the puzzle
            if (currentStage >= puzzleItems.Length) {
                WinPuzzle();
                return;
            }
        } else {
            gameOver = true;
            gameOverScreen.SetActive(true); // The player used the wrong item
        }
    }

    void OnMouseDown() {
        if (gameOver) {
            return;
        }
        TryUseItem();
    }

    void WinPuzzle() {
        gameWinScreen.SetActive(true);
    }

    void OnMouseEnter() {
        highlight.SetActive(true);
    }

    void OnMouseExit() {
        highlight.SetActive(false);
    }

}
