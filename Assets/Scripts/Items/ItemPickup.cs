using UnityEngine;
using UnityEngine.Events;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Item item;
    public Item Item => item;

    private SpriteRenderer spriteRenderer;

    [HideInInspector] public UnityEvent<Transform> OnItemPickup = new();

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.sprite;
    }

    public void GetPickedUpBy(Transform target)
    {
        GetComponent<Collider2D>().enabled = false;
        OnItemPickup.Invoke(target);
    }
}