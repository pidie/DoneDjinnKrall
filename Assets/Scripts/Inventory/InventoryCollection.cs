using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory
{
    public class InventoryCollection : MonoBehaviour
    {
        public static InventoryCollection Instance { get; private set; }
        // public static event Action UpdateInventory;

        private const int InventorySize = 60;
        [SerializeField] private ItemSlot[] itemSlots;

        private void Awake()
        {
            itemSlots = new ItemSlot[InventorySize];
            
            Instance = this;
            for (var i = 0; i < InventorySize; i++)
                itemSlots[i] = new ItemSlot();
        }

        public void AddItem(Item item)
        {
            var firstSlotAvailable = itemSlots.FirstOrDefault(t => t.IsEmpty);
            firstSlotAvailable?.SetItem(item);
        }

        public void RemoveItem(ItemSlot itemSlot) => itemSlot.Clear();

        public void RemoveItemByItem(Item item)
        {
            foreach (var itemSlot in itemSlots)
            {
                if (itemSlot.GetItem() == item)
                    itemSlot.Clear();
            }
        }

        public ItemSlot GetItemSlotByIndex(int index) => itemSlots[index];

        public ItemSlot[] GetAllItems() => itemSlots;

        [ContextMenu(nameof(MoveItemsRight))]
        private void MoveItemsRight()
        {
            var lastItem = itemSlots.Last().GetItem();
            for (var i = InventorySize - 1; i > 0; i--)
                itemSlots[i].SetItem(itemSlots[i-1].GetItem());
            
            itemSlots.First().SetItem(lastItem);
        }

        public void Bind(List<SlotData> slotDatas)
        {
            for (var i = 0; i < itemSlots.Length; i++)
            {
                var slot = itemSlots[i];
                var slotData = slotDatas.FirstOrDefault(t => t.slotName == "General" + i);

                if (slotData == null)
                {
                    slotData = new SlotData() {slotName = "General" + i};
                    slotDatas.Add(slotData);
                }

                slot.Bind(slotData);
            }
        }
    }
}