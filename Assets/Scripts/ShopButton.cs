using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public Item item;  
    public DuckInventory duckInventory;  
    public int index; 

    public void OnClickBuy()
    {
        duckInventory.AddItem(item, index);  
    }

    public void OnClickEquip()
    {
        duckInventory.EquipItem(item, index);  
    }

    public void OnClickCheckifOwned()
    {
        duckInventory.CheckifOwned(item, index);
    }
}
