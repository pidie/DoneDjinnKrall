using UnityEngine;

namespace Inventory.Weapons
{
	[CreateAssetMenu(menuName = "Item/Bow", fileName = "New Bow")]
	public class Bow : Weapon<Bow>
	{
		private void OnEnable()
		{
			damage = new DamageRange(8, 20);
		}
	}
}