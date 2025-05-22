using UnityEngine;
using UnityEngine.UI;

public class CS_AddItemsUI : MonoBehaviour {
    public CS_Inventory inventory;
    public SO_Item targetItem;
    [Space]
    public RawImage thumbnail;

    private void Start() {
        thumbnail.texture = targetItem.itemIcon;
    }

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
