using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum E_itemSlotType {
    Inventory,
    CraftingStation,
    Output
}

public class CS_ItemSlot : MonoBehaviour {
    public SO_Item currentItem = null;
    public E_itemSlotType slotType = E_itemSlotType.Inventory;
    [Space] 
    [SerializeField] private RawImage ItemSlotIcon = null;

    private void Start() {
        RedrawItemSlot();
    }

    /// <summary>
    /// Changes what Item is Present in the Item Slot
    /// and then redraws the UI, it will also dispatch a
    /// notification to the crafting table to tell it to update the
    /// crafting display if needs be.
    /// </summary>
    /// <param name="newItem">new target item</param>
    /// <returns>item slot</returns>
    public CS_ItemSlot SetItemInSlot(SO_Item newItem) {
        currentItem = newItem;
        
        // tell the crafting table to check for new crafting recipies.
        if (slotType == E_itemSlotType.CraftingStation) {
            GetComponentInParent<CS_CraftingStation>().checkCraftingRecipies();
        }
        
        RedrawItemSlot();
        return this;
    }

    /// <summary>
    /// sets the item slot contents to null and will
    /// notify the crafting table to update too
    /// </summary>
    public void ClearItemSlot() {
        currentItem = null;
        
        // tell the crafting table to check for new crafting recipies.
        if (slotType == E_itemSlotType.CraftingStation) {
            GetComponentInParent<CS_CraftingStation>().checkCraftingRecipies();
        }
        
        RedrawItemSlot();
    }

    /// <summary>
    /// Returns the Current item as its item structure
    /// </summary>
    /// <returns>SO_Item</returns>
    public SO_Item GetCurrentItem() {
        return currentItem;
    }

    /// <summary>
    /// Returns the Current items name
    /// </summary>
    /// <returns>string item name</returns>
    public string GetItemName() {
        return currentItem.itemName;
    }

    /// <summary>
    /// Redraws the Item Slot info when called so it represents what is in the item slot
    /// Accuratly at all times
    /// </summary>
    public void RedrawItemSlot() {
        if (currentItem) {
            ItemSlotIcon.GameObject().SetActive(true);
            ItemSlotIcon.texture = currentItem.itemIcon;
        }
        else {
            ItemSlotIcon.GameObject().SetActive(false);
            ItemSlotIcon.texture = null;
        }
    }
}