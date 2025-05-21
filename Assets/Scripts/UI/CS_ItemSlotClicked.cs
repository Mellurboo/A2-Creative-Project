using UnityEngine;

public enum E_ItemSlotBehavour {
    nothing,
    clearItemSlot,
    MoveIntoInventory,
    MoveIntoCrafting
}
public class CS_ItemSlotClicked : MonoBehaviour {
    [SerializeField] E_ItemSlotBehavour ItemSlotBehavour;
    [Space] 
    public CS_Inventory Inventory;
    public CS_CraftingStation CraftingStation;
    
    CS_ItemSlot thisItemSlot;

    private void Start() {
        thisItemSlot = GetComponent<CS_ItemSlot>();
    }

    public void OnItemSlotClicked() {
        switch (ItemSlotBehavour) {
            case E_ItemSlotBehavour.nothing:
                break;
            case E_ItemSlotBehavour.clearItemSlot:
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
                
        }
    }
}
