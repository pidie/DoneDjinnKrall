using UnityEngine;

namespace Flags
{
	[CreateAssetMenu(menuName = "Game Flag/Int")]
	public class GameFlagInt : GameFlag<int>
	{
		protected override void SetFromData(string value)
		{
			if (int.TryParse(value, out var intValue))
				Set(intValue);
		}

		public void Modify(int value) => Set(Value + value);
	}
}