using UnityEngine;

public class KeyPadTrigger : Interactable
{
    public KeyPadUI keypadUI; // Reference to the KeyPadUI script


    protected override void OnMouseDown()
    {
        base.OnMouseDown(); // Call the base class's OnMouseDown method to show the interaction message
        keypadUI.Open(); // Open the keypad UI when the object is clicked
        
    }
}
