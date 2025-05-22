using UnityEngine;
using UnityEngine.UI;

public class CS_AddItemsUI : MonoBehaviour {
    public CS_Inventory inventory;
    public SO_Item targetItem;
    [Space]
    public RawImage thumbnail;
    
    /// <summary>
    /// Construct the UI
    /// </summary>
    private void Start() {
        thumbnail.texture = targetItem.itemIcon;
    }
    
    /// <summary>
    /// Ensures the item being added is unique to the inventory so the player can't stock
    /// many of the same item filling the inventory resulting in a softlock.
    /// </summary>
    public void addItemToInventory() {
        bool isUnique = true;
        foreach (CS_ItemSlot slot in inventory.itemSlots) {
            if (slot.GetCurrentItem() == targetItem) {
                isUnique = false;
            }
        }

        if (isUnique) {
            inventory.getNextFreeSlot().SetItemInSlot(targetItem);
        }
    }
}
