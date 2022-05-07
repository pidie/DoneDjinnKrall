using UnityEngine;

namespace Inventory
{
	public abstract class Item : ScriptableObject
	{
		[TextArea(5, 10)] public string notes;
		public Sprite icon;

		private bool _isEquippable;
		private bool _canViewInInventory;
	}
	
	public abstract class Item<T> : Item where T : Item<T>
	{
		
	}
}