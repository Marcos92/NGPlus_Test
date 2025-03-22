using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image image;

    private ItemSlot currentSlot;
    public ItemSlot Slot => currentSlot;

    void Awake()
    {
        image = GetComponent<Image>();
        currentSlot = GetComponentInParent<ItemSlot>();
        currentSlot.OnSlotUpdate.AddListener(UpdateSlot);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(currentSlot.transform);
        image.raycastTarget = true;
    }

    private void UpdateSlot(ItemSlot slot)
    {
        currentSlot = slot;

        if (slot.Item == null)
        {
            image.enabled = false;
        }
        else
        {
            image.sprite = slot.Item.sprite;
            image.enabled = true;
        }
    }
}