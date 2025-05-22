using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CS_Objective : MonoBehaviour {
    public SO_Item[] items;
    public SO_Item targetItem;
    public CS_ItemSlot[] itemSlots;
    [Space]
    [Header("Text")]
    public string objectiveDescription;
    public TMP_Text objectiveDescriptionText;
    [Space]
    [Header("Image")]
    public RawImage objectiveIcon;
    public Texture2D objectiveCompleteIcon;
    [Space]
    public bool isComplete;
    
    private void Awake() {
        itemSlots[0].SetItemInSlot(items[0]);
        itemSlots[1].SetItemInSlot(items[1]);
        itemSlots[2].SetItemInSlot(items[2]);
        
        itemSlots[3].SetItemInSlot(targetItem);
        
        objectiveDescriptionText.text = objectiveDescription;
    }
    
    public void CompleteObjective() {
        isComplete = true;
        objectiveIcon.texture = objectiveCompleteIcon;
    }
}
