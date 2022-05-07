using System;
using System.Collections.Generic;
using Flags;

namespace Persistence
{
	[Serializable]
	public class GameData
	{
		public List<GameFlagData> gameFlagDatas;
		public List<InteractableData> interactableDatas;
		public List<SlotData> slotDatas;

		public GameData()
		{
			gameFlagDatas = new List<GameFlagData>();
			interactableDatas = new List<InteractableData>();
		}
	}

	[Serializable]
	public class SlotData
	{
		public string slotName;
		public string itemName;
	}
}