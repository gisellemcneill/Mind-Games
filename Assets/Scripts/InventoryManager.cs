using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public int inventorySize = 10; // The size of the inventory
    public List<InventoryItem> items = new List<InventoryItem>(); // Stores the items that are collected by the player
    public InventoryItem selectedItem; // The item that the player is currently selecting
    public InventorySlot[] inventorySlots; // Holds references to the Inventory slots

    // Add an item to the inventory
    public bool AddItem(InventoryItem item) {
        // Check if the inventory is full
        if (items.Count >= inventorySize) {
            return false;
        }
        // Add the item to the inventory
        items.Add(item);
        inventorySlots[items.Count - 1].UpdateSlot(item);
        return true;
    }

    // Select an item from the inventory
    public void SelectItem(InventoryItem item) {
        selectedItem = item;
        Debug.Log("Selected: " + item.itemName);
    }

    // Remove an item from the inventory
    public void RemoveItem(InventoryItem item) {
        int index = items.IndexOf(item);
        if (index == -1) {
            return;
        }
        items.RemoveAt(index);
        // Clear all of the inventory slots
        foreach (InventorySlot slot in inventorySlots) {
            slot.ClearSlot();
        }
        // Refresh the inventory slots
        for (int i = 0; i < items.Count; i++) {
            inventorySlots[i].UpdateSlot(items[i]);
        }
        if (selectedItem == item) {
            selectedItem = null;
        }
    }

    void Start() {
        // Give each inventory slot a reference to the Inventory Manager
        foreach (InventorySlot slot in inventorySlots) {
            slot.inventoryManager = this;
        }
    }

}
