using UnityEngine;
using UnityEngine.EventSystems;

public class ItemConsumer : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();
        ItemSlot slot = draggableItem.Slot;
        Item item = slot.Item;

        if (item.type != ItemType.CONSUMABLE)
        {
            return;
        }

        slot.SetItem(null);
        item.Use();
        InventoryEvent.OnItemConsume.Invoke();
    }
}