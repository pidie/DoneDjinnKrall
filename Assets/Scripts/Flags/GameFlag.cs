using System;
using UnityEngine;

namespace Flags
{
	public abstract class GameFlag : ScriptableObject
	{
		public GameFlagData GameFlagData { get; private set; }
		public event Action FlagDataChanged;
		protected void SendQuestDataChanged() => FlagDataChanged?.Invoke();

		public void Bind(GameFlagData data)
		{
			GameFlagData = data;
			SetFromData(GameFlagData.value);
		}

		protected abstract void SetFromData(string value);
	}

	public abstract class GameFlag<T> : GameFlag
	{
		public T Value { get; private set; }
		private void OnEnable() => Value = default;
		private void OnDisable() => Value = default;

		public void Set(T value)
		{
			Value = value;
			GameFlagData.value = Value.ToString();
			SendQuestDataChanged();
		}
	}

	[Serializable]
	public class GameFlagData
	{
		public string name;
		public string value;
	}
}