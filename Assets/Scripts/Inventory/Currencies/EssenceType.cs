using System;
using UnityEngine;

namespace Inventory.Currencies
{
	[CreateAssetMenu(menuName: "Currencies/Essence Type", fileName: "New Essence Type")]
	public class EssenceType : ScriptableObject
	{
		public string name;
		public Sprite icon;
	}
}