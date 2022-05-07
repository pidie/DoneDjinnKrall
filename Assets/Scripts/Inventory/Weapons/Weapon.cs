namespace Inventory.Weapons
{
	public abstract class Weapon : Item<Weapon>
	{
		public DamageRange damage;
	}
	
	public abstract class Weapon<T> : Weapon where T : Weapon<T>
	{
		
	}
}