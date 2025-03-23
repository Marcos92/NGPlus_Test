using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ItemPickup pickup))
        {

            if (InventoryManager.Instance.AddItem(pickup.Item))
            {
                pickup.GetPickedUpBy(transform);
            }
        }
    }
}