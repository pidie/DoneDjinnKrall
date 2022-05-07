using UnityEngine;

namespace Flags
{
	[CreateAssetMenu(menuName = "Game Flag/Decimal")]
	public class GameFlagDecimal : GameFlag<decimal>
	{
		protected override void SetFromData(string value)
		{
			if (decimal.TryParse(value, out var decimalValue))
				Set(decimalValue);
		}

		public void Modify(decimal value) => Set(Value + value);
	}
}