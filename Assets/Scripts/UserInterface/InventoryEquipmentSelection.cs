using Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class InventoryEquipmentSelection : MonoBehaviour
    {
        private Button[] _buttons;

        private void Awake() => _buttons = GetComponentsInChildren<Button>();

        public void ShowSelectableItems()
        {
            var allItems = InventoryCollection.Instance.GetAllItems();

            for (var i = 0; i < allItems.Length; i++)
            {
                _buttons[i].enabled = allItems[i] != null;
            }
        }
    }
}
