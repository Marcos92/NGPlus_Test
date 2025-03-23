using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private InventoryData data = new();
    public List<Item> InventoryItems => data.InventoryItems;
    public WeaponItem EquippedItem => data.EquippedItem;

    public void UpdateInventory(InventoryData newData)
    {
        data = newData;
    }

    public InventoryData GetData()
    {
        return data;
    }
}