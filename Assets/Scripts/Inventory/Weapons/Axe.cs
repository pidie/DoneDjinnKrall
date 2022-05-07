using UnityEngine;

namespace Inventory.Weapons
{
	[CreateAssetMenu(menuName = "Item/Axe", fileName = "New Axe")]
	public class Axe : Weapon<Axe>
	{
		private void OnEnable()
		{
			damage = new DamageRange(3, 12);
		}
	}
}