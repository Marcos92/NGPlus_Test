using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlotPrefab;
    [SerializeField] private int inventorySize = 30;
    private ItemSlot[] inventorySlots;

    void Awake()
    {
        InventoryEvent.OnItemDrop.AddListener(UpdateInventory);
        InventoryEvent.OnItemConsume.AddListener(UpdateInventory);
    }

    void Start()
    {
        List<Item> inventoryItems = InventoryManager.Instance.InventoryItems;
        inventorySlots = new ItemSlot[inventorySize];
        for (int i = 0; i < inventorySize; i++)
        {
            ItemSlot itemSlot = Instantiate(itemSlotPrefab, transform);

            if (i < inventoryItems.Count)
            {
                itemSlot.SetItem(inventoryItems[i]);
            }
            else
            {
                itemSlot.SetItem(null);
            }

            inventorySlots[i] = itemSlot;
        }
    }

    private void UpdateInventory()
    {
        List<Item> inventoryItems = new();
        for (int i = 0; i < inventorySize; i++)
        {
            inventoryItems.Add(inventorySlots[i].Item);
        }

        InventoryManager.Instance.UpdateInventoryItems(inventoryItems);

        SaveSystem.Instance.Save();
    }
}