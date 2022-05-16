using UnityEngine;

namespace UserInterface
{
    public class InventoryItemButton
    {
        private Button _button;
        private ItemSlot _itemSlot;
        private Image _icon;

        public InventoryItemButton(ItemSlot itemSlot)
        {
            _button = GetComponent<Button>();
            _itemSlot = itemSlot;
            _icon = itemSlot.GetItem().icon;
        }

        // on click, check if item can be set as active button.
        // if not, display the reason it cannot be equipped
        // otherwise, equip it and notify the player that it has been equipped
        //    ie: a sound, vfx, etc
    }
}