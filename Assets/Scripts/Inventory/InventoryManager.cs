using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private Item[] items;

    public Item GetItemAtIndex(int i)
    {
        if (i >= items.Length)
        {
            return null;
        }
        else
        {
            return items[i];
        }
    }
}