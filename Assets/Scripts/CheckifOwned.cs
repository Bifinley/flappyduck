using UnityEngine;

public class CheckifOwned : MonoBehaviour
{
    public Item[] item;
    public DuckInventory duckInventory;
    public int index;

    public void OnClickCheckifOwned()
    {
        for (int i = 0; i < item.Length; i++)
        {
            duckInventory.CheckifOwned(item[i], i); // checking to see if you own items and updating UI (item, index)
        }
    }
}
