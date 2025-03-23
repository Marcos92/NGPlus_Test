using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private string path;

    void Awake()
    {
        path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SAVE_FILE.json";
    }

    public void Save()
    {
        InventoryData inventoryData = InventoryManager.Instance.GetData();
        string data = JsonUtility.ToJson(inventoryData);
        File.WriteAllText(path, data);
        Debug.Log("Game saved!");
        Debug.Log(data);
    }

    public void Load()
    {
        string data = File.ReadAllText(path);
        InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(data);
        InventoryManager.Instance.UpdateInventory(inventoryData);
        Debug.Log("Game loaded!");
        Debug.Log(data);
    }
}