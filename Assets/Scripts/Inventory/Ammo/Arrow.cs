using System;
using Inventory.Weapons;

namespace Inventory.Ammo
{
	public class Arrow : Ammo<Arrow>
	{
		public override Type UsedBy => typeof(Bow);
	}
}