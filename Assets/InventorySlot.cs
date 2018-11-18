using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour {

    Item item;
    public Image icon;
    public Button removeButton;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.sprite;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        Debug.Log("In ClearSlot");
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Debug.Log("In OnRemoveButton");
        Inventory.instance.Remove(item);        
    }
}
