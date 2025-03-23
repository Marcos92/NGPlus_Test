using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private InventoryData data = new();
    public List<Item> InventoryItems => data.InventoryItems;
    public WeaponItem EquippedItem => data.EquippedItem;

    public void UpdateInventoryData(InventoryData newData)
    {
        data = newData;
    }

    public void UpdateInventoryItems(List<Item> newItems)
    {
        data.InventoryItems = newItems;
    }

    public void UpdateEquippedItem(WeaponItem newItem)
    {
        data.EquippedItem = newItem;
    }

    public InventoryData GetData()
    {
        return data;
    }
}