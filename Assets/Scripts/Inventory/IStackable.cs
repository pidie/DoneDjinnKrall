using UnityEngine;

namespace Inventory
{
	public interface IStackable
	{
		int Quantity { get; set; }
		int MaxStackSize { get; set; }

		/// <summary>
		/// Adds two stacks together, leaving anything above the max stack size as the player's selection
		/// </summary>
		/// <returns></returns>
		bool UpdateQuantity(IStackable otherItem); //update quantity and delete extras
	}
}