using UnityEngine;

namespace Inventory.Weapons
{
	[CreateAssetMenu(menuName = "Item/Sword", fileName = "New Sword")]
	public class Sword : Weapon<Sword>
	{
		private void Awake()
		{
			damage = new DamageRange(5, 10);
		}
	}
}