using UnityEngine;

public class CS_Inventory : MonoBehaviour {
    public CS_ItemSlot[] itemSlots;
    
    /// <summary>
    /// returns the whole item slot arry
    /// </summary>
    /// <returns>cs_itemslot</returns>
    public CS_ItemSlot[] getItemSlots(){
        return itemSlots;
    }
    
    /// <summary>
    ///  returns the next free item slot in the inventory
    /// </summary>
    /// <returns>cs_itemslot</returns>
    public CS_ItemSlot getNextFreeSlot() {
        CS_ItemSlot nextFreeSlot = null;
        foreach (CS_ItemSlot slot in itemSlots) {
            if (!slot.currentItem) {
                nextFreeSlot = slot;
            }
        }
        
        return nextFreeSlot;
    }
}
