using UnityEngine;

namespace Flags
{
	[CreateAssetMenu(menuName = "Game Flag/String")]
	public class GameFlagString : GameFlag<string>
	{
		protected override void SetFromData(string value)
		{
			Set(value);
		}
	}
}