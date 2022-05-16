using UnityEngine;

namespace Inventory.Enhancements
{
	public class Enhancement
	{
		public string title;
		public int level;
		public int experience;
		public Sprite icon;
		public Dictionary<Currency, int> cost;
	}
}
