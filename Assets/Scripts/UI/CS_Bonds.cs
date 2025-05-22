using System;
using TMPro;
using UnityEngine;

public class CS_Bonds : MonoBehaviour {
    public int currentBonds = 3;
    public TMP_Text bondText;

    private void Start() {
        updateBondCount();
    }

    public void addBonds() {
        currentBonds++;
        updateBondCount();
    }

    public void removeBonds(int count) {
        currentBonds -= count;
        updateBondCount();
    }
    
    /// <summary>
    /// simply for cleaner code
    /// </summary>
    /// <returns>bond count</returns>
    public int getBonds() {
        return currentBonds;
    }

    public void updateBondCount() {
        bondText.text = $"Bonds: {currentBonds}";
    }
}
