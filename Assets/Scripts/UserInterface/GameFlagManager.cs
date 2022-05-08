using System.Collections.Generic;
using System.Linq;
using Flags;
using UnityEngine;

namespace UserInterface
{
	public class GameFlagManager : MonoBehaviour
	{
		[SerializeField] private GameFlag[] allFlags;
		private Dictionary<string, GameFlag> _flagsByName;
		public static GameFlagManager Instance { get; private set; }

		private void Awake() => Instance = this;

		private void Start() => _flagsByName = allFlags.ToDictionary(k => k.name.Replace(" ", ""), v => v);

		#if UNITY_EDITOR
		private void OnValidate() => allFlags = Extensions.GetAllInstances<GameFlag>();
		#endif
		
		public void Set(string flagName, string value)
		{
			if (_flagsByName.TryGetValue(flagName, out var flag) == false)
			{
				Debug.LogError($"Flag not found {flagName}");
				return;
			}

			switch (flag)
			{
				case GameFlagInt gameFlagInt:
				{
					if (int.TryParse(value, out var gameValueInt))
						gameFlagInt.Set(gameValueInt);
					break;
				}
				case GameFlagBool gameFlagBool:
				{
					if (bool.TryParse(value, out var gameValueBool))
						gameFlagBool.Set(gameValueBool);
					break;
				}
				case GameFlagString gameFlagString:
					gameFlagString.Set(value);
					break;
				case GameFlagDecimal gameFlagDecimal:
				{
					if (decimal.TryParse(value, out var gameValueDecimal))
						gameFlagDecimal.Set(gameValueDecimal);
					break;
				}
			}
		}

		public void Bind(List<GameFlagData> gameFlagDatas)
		{
			foreach (var flag in allFlags)
			{
				var data = gameFlagDatas.FirstOrDefault(t => t.name == flag.name);
				if (data == null)
				{
					data = new GameFlagData() {name = flag.name};
					gameFlagDatas.Add(data);
				}
				flag.Bind(data);
			}
		}
	}
}