using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DuckInventory : MonoBehaviour
{
    public List<Item> ownedItems = new List<Item>();

    [SerializeField] private Item[] allItems;
    [SerializeField] private SpriteRenderer equipmentSlot;
    [SerializeField] private TMP_Text[] priceTags; 
    [SerializeField] private GameObject shopPanel;

    public bool isShopOpen = false;
    public GameObject[] shopOpenButtons;

    public static DuckInventory Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("There can only be one Duck Inventory!");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void Start()
    {
        var saveData = SaveManager.Load();
        if (saveData != null)
        {
            GameMaster.Instance.Score = saveData.score;

            ownedItems.Clear();
            foreach (string id in saveData.ownedItemIDs)
            {
                Item item = System.Array.Find(allItems, i => i.itemID == id);
                if (item != null)
                {
                    ownedItems.Add(item);
                }
            }
        }

        equipmentSlot.enabled = false;
    }
    public void OpenShop()
    {
        if(isShopOpen == false)
        {
            shopPanel.SetActive(true);
            isShopOpen = true;
            GameMaster.Instance.pressSpaceBarUI.SetActive(false);
            GameMaster.Instance.isShopOpenFromGameMaster = true;
        }
    }
    public void CloseShop()
    {
        if(isShopOpen == true)
        {
            shopPanel.SetActive(false);
            isShopOpen = false;
            GameMaster.Instance.pressSpaceBarUI.SetActive(true);
            GameMaster.Instance.isShopOpenFromGameMaster = false;
        }
    }

    public void CheckifOwned(Item item, int index)
    {
        /*if (ownedItems.Contains(item))
        {
            priceTags[index].text = $"{item.itemName}: Owned.";

            if (equipmentSlot.sprite == item.itemSprite)
            {
                priceTags[index].text = $"{item.itemName}: Equipped";
            }
        }*/

        for (int i = 0; i < allItems.Length; i++)
        {
            if (ownedItems.Contains(allItems[i]))
            {
                if (allItems[i] == item)
                {
                    priceTags[i].text = $"{item.itemName}: Equipped";
                }
                else
                {
                    priceTags[i].text = $"{allItems[i].itemName}: Owned.";
                }
            }
            else
            {
                priceTags[i].text = $"{allItems[i].itemName}: ${allItems[i].price}";
            }
        }
    }

    public void AddItem(Item item, int index)
    {
        if (GameMaster.Instance.Score >= item.price)
        {
            if (!ownedItems.Contains(item))
            {
                GameMaster.Instance.Score -= item.price;

                ownedItems.Add(item);
                priceTags[index].text = $"{item.itemName}: Owned"; 
                Debug.Log($"Thank you for buying: {item.itemName}");
            }
        }
        else
        {
            priceTags[index].text = $"{item.itemName}: ${item.price}"; 
            Debug.Log($"You cannot afford: {item.itemName}");
        }
    }

    public void EquipItem(Item item, int index)
    {
        if (ownedItems.Contains(item))
        {
            equipmentSlot.sprite = item.itemSprite;
            equipmentSlot.enabled = true;

            for (int i = 0; i < allItems.Length; i++)
            {
                if (ownedItems.Contains(allItems[i]))
                {
                    if (allItems[i] == item)
                    {
                        priceTags[i].text = $"{item.itemName}: Equipped";
                    }
                    else
                    {
                        priceTags[i].text = $"{allItems[i].itemName}: Owned.";
                    }
                }
                else
                {
                    priceTags[i].text = $"{allItems[i].itemName}: ${allItems[i].price}";
                }
            }
        }
        else
        {
            priceTags[index].text = $"{item.itemName}: ${item.price}";
            Debug.Log("You don't own this item.");
        }
    }

}
