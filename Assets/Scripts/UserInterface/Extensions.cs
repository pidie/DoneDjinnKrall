﻿using UnityEditor;

namespace UserInterface
{
	public static class Extensions
	{
		public static T[] GetAllInstances<T>() where T : UnityEngine.Object
		{
			var guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
			var a = new T[guids.Length];
			for (var i = 0; i < guids.Length; i++)
			{
				var path = AssetDatabase.GUIDToAssetPath(guids[i]);
				a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
			}

			return a;
		}
	}
}