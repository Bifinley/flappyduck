using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Shop/Item")]
public class Item : ScriptableObject
{
    public string itemID;
    public string itemName;
    public int price;
    public Sprite itemSprite;
}
