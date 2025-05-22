using TMPro;
using UnityEngine;

public class CS_CraftingStation : MonoBehaviour {
    public CS_ItemSlot[] itemSlots;
    public CS_ItemSlot resultsSlot;
    [Space] 
    public CS_Bonds bonds;
    public TMP_Text bondsText;
    
    /// <summary>
    /// returns the whole item slot array
    /// </summary>
    /// <returns>cs_itemslot</returns>
    public CS_ItemSlot[] getItemSlots(){
        return itemSlots;
    }
    
    /// <summary>
    /// returns the next free item slot in the inventory as a reference
    /// to be interfaced with
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
    /// Ugly code for checking crafting recipies but that clock won't stop ticking,
    /// it checks for all the possible crafting recipies, and then will check if the player has enough
    /// bonds, if not it will display the appropriate text if it does it will apply the item to the
    /// item slot and redraw.
    /// </summary>
    public void checkCraftingRecipies() {
        bondsText.text = "";
        
        if (itemSlots[0].GetCurrentItem() == SO_ItemStubs.iAcidicStarfury &&
            itemSlots[1].GetCurrentItem() == SO_ItemStubs.iFreshAir &&
            itemSlots[2].GetCurrentItem() == SO_ItemStubs.iFrancium) {

            if (SO_ItemStubs.iPortalPaste.bondValue > bonds.currentBonds) {
                bondsText.text =
                    $"This Craft requires {SO_ItemStubs.iPortalPaste.bondValue} bonds, you have {bonds.currentBonds}";
            }
            else {
                resultsSlot.SetItemInSlot(SO_ItemStubs.iPortalPaste);
                resultsSlot.RedrawItemSlot();
            }
            
            return;
        }
        
        if (itemSlots[0].GetCurrentItem() == SO_ItemStubs.iAcidicStarfury &&
            itemSlots[1].GetCurrentItem() == SO_ItemStubs.iElectrolydium &&
            itemSlots[2].GetCurrentItem() == SO_ItemStubs.iPortalPaste) {
            
            if (SO_ItemStubs.iWormholeInABottle.bondValue > bonds.currentBonds) {
                bondsText.text =
                    $"This Craft requires {SO_ItemStubs.iWormholeInABottle.bondValue} bonds, you have {bonds.currentBonds}";
            }
            else {
                resultsSlot.SetItemInSlot(SO_ItemStubs.iWormholeInABottle);
                resultsSlot.RedrawItemSlot();
            }
            
            return;
        }
        
        if (itemSlots[0].GetCurrentItem() == SO_ItemStubs.iFrancium &&
            itemSlots[1].GetCurrentItem() == SO_ItemStubs.iElectrolydium &&
            itemSlots[2].GetCurrentItem() == SO_ItemStubs.iWormholeInABottle) {
            
            if (SO_ItemStubs.iHumanCapsuleModule.bondValue > bonds.currentBonds) {
                bondsText.text =
                    $"This Craft requires {SO_ItemStubs.iHumanCapsuleModule.bondValue} bonds, you have {bonds.currentBonds}";
            }
            else {
                resultsSlot.SetItemInSlot(SO_ItemStubs.iHumanCapsuleModule);
                resultsSlot.RedrawItemSlot();
            }
            
            return;
        }
        
        resultsSlot.ClearItemSlot();
    }
    
    /// <summary>
    /// clears all items from the crafting table including
    /// the output slot.
    /// </summary>
    public void ClearCraftingStation() {
        foreach (CS_ItemSlot slot in itemSlots) {
            slot.ClearItemSlot();
            bondsText.text = "";
        }
    }
}
