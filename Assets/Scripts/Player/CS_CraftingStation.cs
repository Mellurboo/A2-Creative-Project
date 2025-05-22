using UnityEngine;

public class CS_CraftingStation : MonoBehaviour {
    public CS_ItemSlot[] itemSlots;
    public CS_ItemSlot resultsSlot;
    
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
            if (slot.currentItem == null) {
                nextFreeSlot = slot;
            }
        }
        
        return nextFreeSlot;
    }
    
    /// <summary>
    /// Ugly code for checking crafting recipies but that clock won't stop ticking
    /// </summary>
    public void checkCraftingRecipies() {
        if (itemSlots[0].GetCurrentItem() == SO_ItemStubs.iAcidicStarfury &&
            itemSlots[1].GetCurrentItem() == SO_ItemStubs.iFreshAir &&
            itemSlots[2].GetCurrentItem() == SO_ItemStubs.iFrancium) {
            
            resultsSlot.SetItemInSlot(SO_ItemStubs.iPortalPaste);
            resultsSlot.RedrawItemSlot();
            return;
        }
        
        if (itemSlots[0].GetCurrentItem() == SO_ItemStubs.iAcidicStarfury &&
            itemSlots[1].GetCurrentItem() == SO_ItemStubs.iElectrolydium &&
            itemSlots[2].GetCurrentItem() == SO_ItemStubs.iPortalPaste) {
            
            resultsSlot.SetItemInSlot(SO_ItemStubs.iWormholeInABottle);
            resultsSlot.RedrawItemSlot();
            return;
        }
        
        if (itemSlots[0].GetCurrentItem() == SO_ItemStubs.iFrancium &&
            itemSlots[1].GetCurrentItem() == SO_ItemStubs.iElectrolydium &&
            itemSlots[2].GetCurrentItem() == SO_ItemStubs.iWormholeInABottle) {
            
            resultsSlot.SetItemInSlot(SO_ItemStubs.iHumanCapsuleModule);
            resultsSlot.RedrawItemSlot();
            return;
        }
        
        resultsSlot.ClearItemSlot();
    }

    public void ClearCraftingStation() {
        foreach (CS_ItemSlot slot in itemSlots) {
            slot.ClearItemSlot();
        }
    }
}
