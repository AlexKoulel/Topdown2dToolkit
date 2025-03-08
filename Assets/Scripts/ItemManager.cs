using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

/// <summary>
/// This is a class for managing the player's inventory as well saving it locally to a JSON file.
/// </summary>
public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private string filePath = null,_inventorySaveData,_inventoryLoadData;
    public Inventory inventory = new Inventory();

    private void Start()
    {
        filePath = Application.persistentDataPath + "/SaveData.json";
        CreateSaveFile();
    }

    /// <summary>
    /// Adds interacted item to the list and updates JSON file.
    /// </summary>
    public void AddItem(int item)
    {
        inventory.items[item] = 1;
        SaveToJson();
    }

    /// <summary>
    /// Called upon startup it creates the save data JSON file on C:/Users/user/AppData/LocalLow/Company/GameName/
    /// This method is called in the Start() method of this class for demonstration purposes so it will overwrite it every time.
    /// </summary>
    public void CreateSaveFile()
    {
        filePath = Application.persistentDataPath + "/SaveData.json";
        inventory.items = new List<int> { 0, 0, 0 };
        _inventorySaveData = JsonUtility.ToJson(inventory);
        Debug.Log("File Path: " + filePath);
        Debug.Log("Created Data: " + _inventorySaveData);
        System.IO.File.WriteAllText(filePath, _inventorySaveData);
        Debug.Log("Save file created.");
    }

    /// <summary>
    /// Saves data to JSON file.
    /// </summary>
    public void SaveToJson()
    {
        _inventorySaveData = JsonUtility.ToJson(inventory);
        Debug.Log("File Path: " + filePath);
        Debug.Log("Save Data: " + _inventorySaveData);
        System.IO.File.WriteAllText(filePath, _inventorySaveData);
    }

    /// <summary>
    /// Loads data from JSON file.
    /// </summary>
    public void LoadFromJson()
    {

        inventory.items = new List<int> { 0, 0, 0 };
        filePath = Application.persistentDataPath + "/SaveData.json";
        _inventoryLoadData = System.IO.File.ReadAllText(filePath);
        inventory = JsonUtility.FromJson<Inventory>(_inventoryLoadData);
        Debug.Log("File Path: " + filePath);
        Debug.Log("Loaded Data: " + _inventoryLoadData); 
    }
}
public class Inventory
{
    public List<int> items;
}
