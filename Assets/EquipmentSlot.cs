using TMPro;
using UnityEngine;

public class EquipmentSlot : MonoBehaviour
{
    private ItemSlot slot;
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text attackLabel;

    void Awake()
    {
        ItemSlotInteraction.OnItemDrop.AddListener(UpdateEquipment);
    }

    void Start()
    {
        slot = GetComponentInChildren<ItemSlot>();
        SetItem(InventoryManager.Instance.EquippedItem);
    }

    public void SetItem(Item item)
    {
        if (item != null && item.type != ItemType.WEAPON)
        {
            return;
        }

        WeaponItem weapon = item as WeaponItem;
        slot.SetItem(weapon);
        SetText(weapon);
    }

    private void SetText(WeaponItem weapon)
    {
        if (weapon != null)
        {
            nameLabel.text = weapon.title;
            attackLabel.text = "ATK: " + weapon.damage;
        }
        else
        {
            nameLabel.text = "(NO WEAPON)";
            attackLabel.text = "ATK: " + 0;
        }
    }

    private void UpdateEquipment(Item item)
    {
        if (item != null && item.type != ItemType.WEAPON)
        {
            return;
        }

        WeaponItem weapon = (WeaponItem)slot.Item;
        InventoryManager.Instance.UpdateEquippedItem(weapon);
        SaveSystem.Instance.Save();
        SetText(weapon);
    }
}
