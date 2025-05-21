using System;
using UnityEngine;

public class SO_ItemStubs : MonoBehaviour {
    public static SO_Item iAcidicStarfury;
    public static SO_Item iElectrolydium;
    public static SO_Item iFrancium;
    public static SO_Item iFreshAir;
    public static SO_Item iHumanCapsuleModule;
    public static SO_Item iPortalPaste;
    public static SO_Item iWormholeInABottle;
    
    [SerializeField] private SO_Item AcidicStarfury;
    [SerializeField] private SO_Item Electrolydium;
    [SerializeField] private SO_Item Francium;
    [SerializeField] private SO_Item FreshAir;
    [SerializeField] private SO_Item HumanCapsuleModule;
    [SerializeField] private SO_Item PortalPaste;
    [SerializeField] private SO_Item WormholeInABottle;
    
    /// <summary>
    /// Reflecting onto the static classes
    /// </summary>
    private void Awake() {
        iAcidicStarfury = AcidicStarfury;
        iElectrolydium = Electrolydium;
        iFrancium = Francium;
        iFreshAir = FreshAir;
        iHumanCapsuleModule = HumanCapsuleModule;
        iPortalPaste = PortalPaste;
        iWormholeInABottle = WormholeInABottle;
    }
}