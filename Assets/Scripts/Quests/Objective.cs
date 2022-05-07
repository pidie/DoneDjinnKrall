using System;
using Flags;
using UnityEngine;

namespace Quests
{
	/// <summary>
	/// Each Step of a Quest consists of Objectives; Objectives can be completed in any order.
	/// </summary>
	[Serializable]
	public class Objective
	{
		[SerializeField] private ObjectiveType objectiveType;
		[SerializeField] private GameFlag gameFlag;
		[Tooltip("The required amount for this game flag to return true")]
		[SerializeField] private int required;

		public GameFlag GameFlag => gameFlag;

		public enum ObjectiveType
		{
			GameFlag,
			Item,
			Kill,
		}

		public bool IsCompleted
		{
			get
			{
				switch (objectiveType)
				{
					case ObjectiveType.GameFlag:
					{
						if (gameFlag is GameFlagBool flagBool)
							return flagBool.Value;
						if (gameFlag is GameFlagInt flagInt)
							return flagInt.Value >= required;
						return false;
					}
					default:
						return false;
				}
			}
		}

		public override string ToString()
		{
			switch (objectiveType)
			{
				case ObjectiveType.GameFlag:
				{
					if (gameFlag is GameFlagBool)
						return gameFlag.name;
					if (gameFlag is GameFlagInt flagInt)
						return $"{flagInt.name} {flagInt.Value}/{required}";
					return "Invalid Objective Type";
				}
				default:
					return objectiveType.ToString();
			}
		}
	}
}