using System;
using UnityEngine;

namespace Inventory
{
	// todo : rename to InventoryItemSlot
	[Serializable]
	public class ItemSlot
	{
		public event Action ItemChanged;
		public bool IsEmpty => _item == null;
		
		private Item _item;
		private SlotData _slotData;
		private string[] equipmentCategories;

		public void SetItem(Item item)
		{
			_slotData ??= new SlotData();

			var previousItem = item;
			_item = item;
			_slotData.itemName = item?.name ?? string.Empty;
			
			if (previousItem != item)
				ItemChanged?.Invoke();
		}

		public Item GetItem() => _item;

		public void Clear() => _item = null;

		public string[] GetEquipmentCategories() => equipmentCategories;

		public void Bind(SlotData slotData)
		{
			_slotData = slotData;
			var item = Resources.Load<Item>("Items/" + slotData.itemName);
			SetItem(item);
		}
	}
	
	// todo : rename to InventoryItemSlotData
	[Serializable]
	public class SlotData
	{
		public string slotName;
		public string itemName;
	}
}