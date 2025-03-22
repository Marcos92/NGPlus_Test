using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemSlotInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;
    public UnityEvent<Item> OnItemDrop;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnter.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnExit.Invoke();
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnItemDrop.Invoke(eventData.pointerDrag.GetComponent<Item>());
    }
}