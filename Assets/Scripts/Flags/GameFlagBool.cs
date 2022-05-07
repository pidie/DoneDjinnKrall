using UnityEngine;

namespace Flags
{
	[CreateAssetMenu(menuName = "Game Flag/Bool")]
	public class GameFlagBool : GameFlag<bool>
	{
		protected override void SetFromData(string value)
		{
			if (bool.TryParse(value, out var boolValue))
				Set(boolValue);
		}
	}
}