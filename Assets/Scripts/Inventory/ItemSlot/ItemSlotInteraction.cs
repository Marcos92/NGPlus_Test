using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemSlotInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDropHandler
{
    private ItemSlot slot;

    [HideInInspector] public UnityEvent OnEnter = new();
    [HideInInspector] public UnityEvent OnExit = new();
    [HideInInspector] public UnityEvent<Item> OnItemDrag = new();
    [HideInInspector] public UnityEvent<Item> OnItemDrop = new();
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}