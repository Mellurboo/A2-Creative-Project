using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_SwapUI : MonoBehaviour {
    public GameObject OldDisable;
    public GameObject NewEnable;
    [Space]
    public CS_CraftingStation craftingStation;
    
    /// <summary>
    /// Disable and Enable UI based on what is assigned, will also notify the crafting table
    /// </summary>
    public void SwapUI() {
        OldDisable.SetActive(false);
        NewEnable.SetActive(true);
        craftingStation.checkCraftingRecipies();
    }
}
