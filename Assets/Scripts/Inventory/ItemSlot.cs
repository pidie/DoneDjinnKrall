using System;
using Persistence;

namespace Inventory
{
	[Serializable]
	public class ItemSlot
	{
		private Item _item;
		private SlotData _slotData;

		public bool IsEmpty => _item == null;

		public void SetItem(Item item)
		{
			_item = item;
			_slotData.itemName = item?.name ?? string.Empty;
		}

		public Item GetItem() => _item;

		public void Clear() => _item = null;

		public void Bind(SlotData slotData)
		{
			_slotData = slotData;
			// SetItem();
		}
	}
}