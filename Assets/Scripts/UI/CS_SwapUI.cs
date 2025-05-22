using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_SwapUI : MonoBehaviour {
    public GameObject OldDisable;
    public GameObject NewEnable;
    [Space]
    public CS_CraftingStation craftingStation;

    public void SwapUI() {
        OldDisable.SetActive(false);
        NewEnable.SetActive(true);
        craftingStation.checkCraftingRecipies();
    }
}
