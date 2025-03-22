using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemSlotInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDropHandler
{
    private ItemSlot slot;

    [HideInInspector] public UnityEvent OnEnter;
    [HideInInspector] public UnityEvent OnExit;
    [HideInInspector] public UnityEvent<Item> OnItemDrag;
    [HideInInspector] public UnityEvent<Item> OnItemDrop;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnter.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnExit.Invoke();
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