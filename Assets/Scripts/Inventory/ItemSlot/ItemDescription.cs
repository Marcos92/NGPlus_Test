using TMPro;
using UnityEngine;

public class ItemDescription : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;

    void Start()
    {
        InventoryEvent.OnItemSelect.AddListener(UpdateText);
        InventoryEvent.OnItemUnselect.AddListener(ClearText);
        ClearText();
    }

    private void ClearText()
    {
        title.text = "";
        description.text = "";
    }

    private void UpdateText(Item item)
    {
        title.text = item.title;
        description.text = item.description;
    }
}