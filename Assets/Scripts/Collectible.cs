using UnityEngine;

public class Collectible : Interactable
{
    public InventoryManager inventoryManager;
    public InventoryItem item;

    protected override void OnMouseDown() {
        if (OpeningScene.isPlaying) {
            return;
        }
        dialogueManager.ShowDialogue(interactionMessage, speakerPicture);

        bool added = inventoryManager.AddItem(item); // Add the item to the inventory

        if (added) {
            gameObject.SetActive(false); // Remove the object from the scene
        }
    }
}
