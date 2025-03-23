using System.IO;
using UnityEngine;

public class SaveSystem : Singleton<SaveSystem>
{
    private string path;

    void Start()
    {
        path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SAVE_FILE.json";
        Load();
    }

    public void Save()
    {
        InventoryData inventoryData = InventoryManager.Instance.GetData();
        string data = JsonUtility.ToJson(inventoryData);
        File.WriteAllText(path, data);
    }

    public void Load()
    {
        string data = File.ReadAllText(path);
        InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(data);
        InventoryManager.Instance.UpdateInventoryData(inventoryData);
    }
}