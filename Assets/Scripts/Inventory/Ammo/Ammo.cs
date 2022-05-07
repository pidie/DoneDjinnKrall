using System;
using UnityEngine;

namespace Inventory.Ammo
{
	public abstract class Ammo : Item<Ammo>, IStackable
	{
		public int Quantity { get; set; }
		public int MaxStackSize { get; set; } = 40;

		public virtual Type UsedBy => null;
		public virtual bool UpdateQuantity(IStackable otherItem) => false;
	}

	public abstract class Ammo<T> : Ammo where T : Ammo<T>
	{
		public override bool UpdateQuantity(IStackable otherItem)
		{
			if (otherItem.Quantity < 1)
			{
				Debug.LogWarning($"Cannot have a stack size of less than 1. {otherItem}: {otherItem.Quantity}");
				return false;
			}
			
			if (otherItem is T)
			{
				var otherQuantity = otherItem.Quantity;
				if (Quantity + otherQuantity > MaxStackSize)
				{
					otherItem.Quantity = otherQuantity + Quantity - MaxStackSize;
					Quantity = MaxStackSize;
				}
				else if (Quantity == MaxStackSize)
				{
					Debug.LogWarning("Already at max stack size!");
					return false;
				}
				else
				{
					Quantity += otherQuantity;
					otherItem.Quantity -= otherQuantity;
				}
				return true;
			}
			return false;
		}
	}
}