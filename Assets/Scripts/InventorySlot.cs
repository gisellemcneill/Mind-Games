using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image itemIcon;
    public TMP_Text itemName;
    public InventoryManager inventoryManager;
    private InventoryItem currentItem; // The item the slot is currently displaying
    private Button slotButton;

    void Awake() {
        slotButton = GetComponent<Button>();
        slotButton.onClick.AddListener(OnSlotClicked);
    }

    void OnSlotClicked() {
        if (currentItem != null) {
            inventoryManager.SelectItem(currentItem);
        }
    }

    // Update the slot with an inventory item
    public void UpdateSlot(InventoryItem item) {
        currentItem = item;
        itemName.text = item.itemName; // Display the item name
        // Display the item icon if it exists
        if (item.itemIcon != null) {
            itemIcon.sprite = item.itemIcon;
            itemIcon.enabled = true;
        } else {
            itemIcon.enabled = false;
        }
    }

    // Clear the slot
    public void ClearSlot() {
        currentItem = null;
        itemIcon.enabled = false;
        itemName.text = "";
    }
}
