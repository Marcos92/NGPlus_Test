using TMPro;
using UnityEngine;

public class EquipmentSlot : MonoBehaviour
{
    private ItemSlot slot;
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text attackLabel;

    void Awake()
    {
        InventoryEvent.OnItemDrop.AddListener(UpdateEquipment);
        slot = GetComponentInChildren<ItemSlot>();
    }

    void Start()
    {
        SetItem(InventoryManager.Instance.EquippedItem);
    }

    public void SetItem(Item item)
    {
        WeaponItem weapon = item as WeaponItem;
        slot.SetItem(weapon);
        SetText(weapon);
    }

    private void SetText(WeaponItem item)
    {
        if (item != null)
        {
            nameLabel.text = item.title;
            attackLabel.text = "ATK: " + item.Weapon.Damage;
        }
        else
        {
            nameLabel.text = "(NO WEAPON)";
            attackLabel.text = "ATK: " + 0;
        }
    }

    private void UpdateEquipment()
    {
        WeaponItem item = (WeaponItem)slot.Item;
        InventoryManager.Instance.UpdateEquippedItem(item);
        SaveSystem.Instance.Save();
        SetText(item);
        InventoryEvent.OnItemEquip.Invoke(item);
    }
}