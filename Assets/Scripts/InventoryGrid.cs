using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlotPrefab;
    [SerializeField] private int inventorySize = 30;

    void Awake()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            Instantiate(itemSlotPrefab, transform);
        }
    }
}