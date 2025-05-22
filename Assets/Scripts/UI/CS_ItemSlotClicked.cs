using UnityEngine;

public enum E_ItemSlotBehavour {
    Nothing,
    ClearItemSlot,
    MoveIntoInventory,
    MoveIntoCrafting,
    Objective
}
public class CS_ItemSlotClicked : MonoBehaviour {
    [SerializeField] E_ItemSlotBehavour ItemSlotBehavour;
    [Space] 
    public CS_Inventory Inventory;
    public CS_CraftingStation CraftingStation;
    public CS_Objectives Objectives;
    public CS_Bonds Bonds;
    
    CS_ItemSlot thisItemSlot;

    private void Start() {
        thisItemSlot = GetComponent<CS_ItemSlot>();
    }

    public void OnItemSlotClicked() {
        switch (ItemSlotBehavour) {
            case E_ItemSlotBehavour.Nothing:
                break;
            case E_ItemSlotBehavour.ClearItemSlot:
                thisItemSlot.ClearItemSlot();
                break;
            case E_ItemSlotBehavour.MoveIntoInventory:
                if (Inventory.getNextFreeSlot()) {
                    Inventory.getNextFreeSlot().SetItemInSlot(thisItemSlot.currentItem);
                }
                thisItemSlot.ClearItemSlot();
                break;
            case E_ItemSlotBehavour.MoveIntoCrafting:
                if (CraftingStation.getNextFreeSlot()) {
                    CraftingStation.getNextFreeSlot().SetItemInSlot(thisItemSlot.currentItem);
                }
                thisItemSlot.ClearItemSlot();
                break;
            case E_ItemSlotBehavour.Objective:
                if (thisItemSlot.currentItem) {
                    Inventory.getNextFreeSlot().SetItemInSlot(thisItemSlot.currentItem);
                    
                    if (Objectives.queryObjectives(thisItemSlot.currentItem)) {

                        if (thisItemSlot.GetCurrentItem() == SO_ItemStubs.iPortalPaste) {
                            Bonds.removeBonds(SO_ItemStubs.iPortalPaste.bondValue);
                        }
                        
                        if (thisItemSlot.GetCurrentItem() == SO_ItemStubs.iWormholeInABottle) {
                            Bonds.removeBonds(SO_ItemStubs.iWormholeInABottle.bondValue);
                        }
                        
                        if (thisItemSlot.GetCurrentItem() == SO_ItemStubs.iHumanCapsuleModule) {
                            Bonds.removeBonds(SO_ItemStubs.iHumanCapsuleModule.bondValue);
                        }
                    }

                    CraftingStation.ClearCraftingStation();
                }
                break;
                
        }
    }
}
