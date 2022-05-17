using UnityEngine;

namespace Inventory.Currencies
{
	[CreateAssetMenu(menuName = "Currencies/Essence Type", fileName = "New Essence Type")]
	public class EssenceType : ScriptableObject, IAccruable
	{
		public new string name;
		public Sprite icon;
	}
}