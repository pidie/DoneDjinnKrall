using System;
using UnityEngine;

namespace Inventory.Ammo
{
	public abstract class Ammo : Item
	{
		public int Quantity { get; set; }
		public int MaxStackSize { get; set; } = 40;

		public virtual Type UsedBy => null;
		public virtual bool UpdateQuantity(IStackable otherItem) => false;
	}

	public abstract class Ammo<T> : Ammo where T : IStackable
	{
		public override bool UpdateQuantity(Ammo<T> stack)
        {
            var sum = Quantity + stack.Quantity;

            if (Quantity != MaxStackSize)
            {
                if (sum > MaxStackSize)
                {
                    stack.Quantity = sum - MaxStackSize;
                    Quantity = MaxStackSize;
                }
                else
                {
                    Quantity += stack.Quantity;
                    stack.Quantity -= stack.Quantity;
                }
                return true;
            }

            return false;
        }
    }
}