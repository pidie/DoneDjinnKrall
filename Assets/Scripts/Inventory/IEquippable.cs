namespace Inventory
{
    /// <summary> Used by items that can be equipped in the inventory. </summary>
    public interface IEquippable
    {
        public bool IsEquipped { get; set; }

        public void EquipItem(Item item);

        // item can be added to a list of unequipped items
        /* 
    EquipItem(Item item)
    {
        if (!unequippedItems.Contains(item))
            throw new Exception($"Item must be in inventory and unequipped; tried {item.name} ")

        if (activeItem != null)
            unequippedItems.Add(UnequipItem(activeItem));

        activeItem = item;
    }
    */
        public Item UnequipItem(Item item);
    }
}

// todo : move this functionality to be handled solely by the InventoryManager or the InventoryCollection