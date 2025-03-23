using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemSlotInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    private ItemSlot slot;

    [SerializeField] private ItemType itemType = ItemType.ALL;

    [HideInInspector] public UnityEvent OnEnter = new();
    [HideInInspector] public UnityEvent OnExit = new();
    //[HideInInspector] public UnityEvent<Item> OnItemDrag = new();
    [HideInInspector] public static UnityEvent<Item> OnItemDrop = new();
    [HideInInspector] public static UnityEvent<Item> OnItemSelect = new();
    [HideInInspector] public static UnityEvent OnItemUnselect = new();

    void Awake()
    {
        slot = GetComponent<ItemSlot>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnter.Invoke();

        if (slot.Item != null)
        {
            OnItemSelect.Invoke(slot.Item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnExit.Invoke();
        OnItemUnselect.Invoke();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemSlot otherSlot = eventData.pointerDrag.GetComponent<DraggableItem>().Slot;

        if (otherSlot.Item != null && itemType != ItemType.ALL && otherSlot.Item.type != itemType)
        {
            return;
        }

        SwapItems(otherSlot);
        OnItemDrop.Invoke(slot.Item);
    }

    private void SwapItems(ItemSlot otherSlot)
    {
        Item currentItem = slot.Item;
        Item otherItem = otherSlot.Item;

        slot.SetItem(otherItem);
        otherSlot.SetItem(currentItem);
    }
}