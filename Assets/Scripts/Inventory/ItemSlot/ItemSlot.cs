using UnityEngine;
using UnityEngine.Events;

public class ItemSlot : MonoBehaviour
{
    private Item item;
    public Item Item => item;

    [HideInInspector] public UnityEvent<Item> OnItemUpdate = new();

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