using UnityEngine;
using UnityEngine.Events;

public class ItemSlot : MonoBehaviour
{
    private Item item;

    private readonly UnityEvent<Item> onItemUpdate = new();
    public UnityEvent<Item> OnItemUpdate => onItemUpdate;

    public void SetItem(Item item)
    {
        this.item = item;
        OnItemUpdate.Invoke(item);
    }

    public void RemoveItem()
    {
        item = null;
        OnItemUpdate.Invoke(null);
    }
}