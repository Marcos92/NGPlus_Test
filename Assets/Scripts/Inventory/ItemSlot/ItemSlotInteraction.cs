using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemSlotInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    private ItemSlot slot;

    [SerializeField] private ItemType itemType = ItemType.ALL;

    [HideInInspector] public UnityEvent OnEnter = new();
    [HideInInspector] public UnityEvent OnExit = new();


    void Awake()
    {
        slot = GetComponent<ItemSlot>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnter.Invoke();

        if (slot.Item != null)
        {
            InventoryEvent.OnItemSelect.Invoke(slot.Item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnExit.Invoke();
        InventoryEvent.OnItemUnselect.Invoke();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemSlot otherSlot = eventData.pointerDrag.GetComponent<DraggableItem>().Slot;

        if (otherSlot.Item != null && itemType != ItemType.ALL && otherSlot.Item.type != itemType)
        {
            return;
        }

        SwapItems(otherSlot);
        InventoryEvent.OnItemDrop.Invoke();
    }

    private void SwapItems(ItemSlot otherSlot)
    {
        Item currentItem = slot.Item;
        Item otherItem = otherSlot.Item;

        slot.SetItem(otherItem);
        otherSlot.SetItem(currentItem);
    }
}