using System;
using UnityEngine;

namespace Inventory
{
	[Serializable]
	public class ItemSlot
	{
		public event Action ItemChanged;
		public bool IsEmpty => _item == null;
		
		private Item _item;
		private SlotData _slotData;


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


		public void Bind(SlotData slotData)
		{
			_slotData = slotData;
			var item = Resources.Load<Item>("Items/" + slotData.itemName);
			SetItem(item);
		}
	}
	
	[Serializable]
	public class SlotData
	{
		public string slotName;
		public string itemName;
	}
}