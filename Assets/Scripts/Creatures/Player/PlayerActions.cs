using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Creatures.Player;
using Player;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
	private Tile _tile;

	private void Awake()
	{
		_tile = GetComponentInParent<PlayerMovement>().GetPosition();
	}

	private bool IsAdjacentToEnemy()
	{
		foreach (var tile in _tile.GetAdjacentTiles())
		{
			if (!tile.GetIsEmpty())
			{
				foreach (var element in tile.GetContents())
				{
					if (element.GetComponent<EnemyBehaviorTileBased>())
					{
						print("adjacent to enemy!");
						return true;
					}
				}
			}
		}
		
		return false;
	}

	private void OnMouseDown()
	{
		IsAdjacentToEnemy();
	}
}
