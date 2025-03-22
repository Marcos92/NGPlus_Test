using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlotPrefab;
    [SerializeField] private int inventorySize = 30;
    private ItemSlot[] inventorySlots;

    void Start()
    {
        inventorySlots = new ItemSlot[inventorySize];
        for (int i = 0; i < inventorySize; i++)
        {
            ItemSlot itemSlot = Instantiate(itemSlotPrefab, transform);
            itemSlot.SetItem(InventoryManager.Instance.GetItemAtIndex(i));
            inventorySlots[i] = itemSlot;
        }
    }
}