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
                Objectives.queryObjectives(thisItemSlot.currentItem);
                break;
                
        }
    }
}
