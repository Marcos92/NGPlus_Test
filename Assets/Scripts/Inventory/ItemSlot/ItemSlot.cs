using UnityEngine;
using UnityEngine.Events;

public class ItemSlot : MonoBehaviour
{
    private Item item;
    public Item Item => item;

    [HideInInspector] public UnityEvent<ItemSlot> OnSlotUpdate = new();

    public void SetItem(Item newItem)
    {
        item = newItem;
        OnSlotUpdate.Invoke(this);
    }
}