using System;
using Inventory.Weapons;

namespace Inventory.Ammo
{
	public class Arrow : Ammo<Arrow>, IStackable
	{
		public override Type UsedBy => typeof(Bow);
	}
}