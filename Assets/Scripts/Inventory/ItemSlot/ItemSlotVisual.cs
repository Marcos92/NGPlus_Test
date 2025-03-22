using UnityEngine;
using UnityEngine.UI;

public class ItemSlotVisual : MonoBehaviour
{
    [SerializeField] private Image image;
    private ItemSlot slot;

    void Awake()
    {
        slot = GetComponent<ItemSlot>();
        slot.OnItemUpdate.AddListener(UpdateItem);
        image.enabled = false;
        image.preserveAspect = true;
    }

    private void UpdateItem(Item item)
    {
        if (item != null)
        {
            image.sprite = item.sprite;
            image.enabled = true;
        }
        else
        {
            image.sprite = null;
            image.enabled = false;
        }
    }
}