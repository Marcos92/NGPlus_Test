using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private InventoryData data = new();
    public List<Item> InventoryItems => data.InventoryItems;
    public WeaponItem EquippedItem => data.EquippedItem;

    public void UpdateInventoryData(InventoryData newData)
    {
        UpdateInventoryItems(newData.InventoryItems);
        UpdateEquippedItem(newData.EquippedItem);
    }

    public void UpdateInventoryItems(List<Item> newItems)
    {
        data.InventoryItems = newItems;
    }

    public void UpdateEquippedItem(WeaponItem newItem)
    {
        InventoryEvent.OnItemEquip.Invoke(newItem);
        data.EquippedItem = newItem;
    }

    public InventoryData GetData()
    {
        return data;
    }

    public bool AddItem(Item item)
    {
        //Add item to the end of the list if the inventory isn't full
        if (data.InventoryItems.Count < InventoryData.maxInventorySize)
        {
            data.InventoryItems.Add(item);
            SaveSystem.Instance.Save();
            return true;
        }

        //Check if there's an empty space and add item there
        foreach (Item i in data.InventoryItems)
        {
            if (i == null)
            {
                int index = data.InventoryItems.IndexOf(i);
                data.InventoryItems[index] = item;
                SaveSystem.Instance.Save();
                return true;
            }
        }

        return false;
    }
}