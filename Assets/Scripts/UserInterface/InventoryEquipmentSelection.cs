using Inventory;
using Inventory.Enhancements;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    // todo : rename to InventoryItemSelection
    public class InventoryEquipmentSelection : MonoBehaviour
    {
        private Button[] _buttons;
        private string _equipmentCategory;

        private void Awake() 
        {
            _buttons = new Button[InventoryCollection.Instance.inventorySize];
            foreach (var button in _buttons)
                button.enabled = false;
        }

        // this method is called as an event by the buttons in the EquipmentSelection section.
        public string SetEquipmentCategory(string category) => _equipmentCategory = category;

        public void ShowSelectableItems()
        {
            var allItems = InventoryCollection.Instance.GetAllItems();

            for (var i = 0; i < allItems.Length; i++)
            {
                _buttons[i].enabled = allItems[i] != null;
            }

            // get items that match the current equipment category in a collection
            // set _buttons = new Button[collection.Length];
            // for each button in the list of buttons,
            // set the name of button[i] to the name of collection[i]
            // also set the button to EquipItem(collection[i]);
        }

        public static bool PurchaseRequest(Enhancement enhancement)
        {
            foreach (var entry in enhancement.cost)
            {
                var currency = entry.Key;
                var amount = entry.Value;
                // var currency = typeof(entry.Key);

                // entry.Key, entry.Value
                // if the total of the currency is less than the cost:
                // add the currency to a list
                // prompt insufficient funds
                // return false
            }

            return true;
        }
    }
}