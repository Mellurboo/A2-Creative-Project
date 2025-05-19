using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Creative Project/Item")]
public class SO_Item : ScriptableObject {
    public string itemName;
    public string itemDescription;
    public Texture2D itemIcon;
}