using UnityEngine;

namespace Inventory.Currencies
{
	[CreateAssetMenu(menuName = "Essence/Essence", fileName = "New Essence")]
	public class Essence : Currency<EssenceType>
	{
		public string name => $"{EssenceType} Essence";
		public Sprite icon => essenceType.icon;

		public Essence(EssenceType e)
		{
			name = e.name;
			icon = e.icon;
		}
	}
}