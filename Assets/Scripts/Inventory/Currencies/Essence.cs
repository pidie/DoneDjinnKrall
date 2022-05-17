using UnityEngine;

namespace Inventory.Currencies
{
	[CreateAssetMenu(menuName = "Essence/Essence", fileName = "New Essence")]
	public class Essence : Currency<EssenceType>, IAccruable
	{
		public string Name
		{
			get => $"{typeof(EssenceType)} Essence";
			set => throw new System.NotImplementedException();
		}

		// public Sprite Icon
		// {
		// 	get => essenceType.icon;
		// 	set => essenceType.icon = value;
		// }

		public Essence(EssenceType e)
		{
			Name = e.name;
			// Icon = e.icon;
		}
	}
}