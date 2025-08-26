using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int score = 0;
    public List<string> ownedItemIDs = new List<string>();
}

public static class SaveManager
{
    private static readonly string SavePath = Path.Combine(Application.persistentDataPath, "flappyduck.json");

    public static void Save(int score, List<Item> ownedItems)
    {
        SaveData data = new SaveData
        {
            score = score,
            ownedItemIDs = new List<string>()
        };

        foreach (Item item in ownedItems)
        {
            data.ownedItemIDs.Add(item.itemID);
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);
        Debug.Log("Game data saved to: " + SavePath);
    }

    public static SaveData Load()
    {
        if (!File.Exists(SavePath))
        {
            Debug.Log("No save file found.");
            return null;
        }

        string json = File.ReadAllText(SavePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        Debug.Log("Game data loaded from: " + SavePath);
        return data;
    }

    public static void Clear()
    {
        if (File.Exists(SavePath))
        {
            File.Delete(SavePath);
            Debug.Log("Save file deleted.");
        }
    }
}
