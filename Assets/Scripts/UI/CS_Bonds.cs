using System;
using TMPro;
using UnityEngine;

public class CS_Bonds : MonoBehaviour {
    public int currentBonds = 3;
    public TMP_Text bondText;
    
    private void Start() {
        updateBondCount();
    }
    
    /// <summary>
    /// Increments the bond count and updates the display
    /// </summary>
    public void addBonds() {
        currentBonds++;
        updateBondCount();
    }
    
    /// <summary>
    /// removes count amount of bonds from the player and updates the
    /// display
    /// </summary>
    /// <param name="count">value of bonds to remove</param>
    public void removeBonds(int count) {
        currentBonds -= count;
        updateBondCount();
    }
    
    /// <summary>
    /// helper function to get bond count
    /// </summary>
    /// <returns>bond count</returns>
    public int getBonds() {
        return currentBonds;
    }
    
    /// <summary>
    /// apply string interpolation to display how many bonds the player has
    /// </summary>
    public void updateBondCount() {
        bondText.text = $"Bonds: {currentBonds}";
    }
}
