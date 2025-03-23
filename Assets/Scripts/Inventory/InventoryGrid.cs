using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlotPrefab;
    private List<ItemSlot> inventorySlots = new();

    void Awake()
    {
        InventoryEvent.OnItemDrop.AddListener(UpdateInventory);
        InventoryEvent.OnItemConsume.AddListener(UpdateInventory);

        for (int i = 0; i < InventoryData.maxInventorySize; i++)
        {
            ItemSlot itemSlot = Instantiate(itemSlotPrefab, transform);
            inventorySlots.Add(itemSlot);
        }
    }

    void OnEnable()
    {
        List<Item> inventoryItems = InventoryManager.Instance.InventoryItems;
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            inventorySlots[i].SetItem(inventoryItems[i]);
        }
    }

    private void UpdateInventory()
    {
        List<Item> inventoryItems = new();

        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventoryItems.Add(inventorySlots[i].Item);
        }

        InventoryManager.Instance.UpdateInventoryItems(inventoryItems);

        SaveSystem.Instance.Save();
    }
}