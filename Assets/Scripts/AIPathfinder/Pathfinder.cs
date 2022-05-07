using System.Collections.Generic;
using UnityEngine;

namespace AIPathfinder 
{
	// todo : set tiles as not walkable if they are valid tiles but are not traversable
	public class Pathfinder : MonoBehaviour
	{
		private PathNode _originNode;
		private PathNode _targetNode;
		private Heap<PathNode> _openNodes;
		private HashSet<PathNode> _closedNodes;
		private List<Tile> _path;
		private Tile _originTile;
		private Tile _targetTile;

		private int _noPathCount;

		/// <summary>
		/// Create a walkable path as a list of type Tile.
		/// </summary>
		/// <param name="origin">the origin point of the path</param>
		/// <param name="target">the final Tile on the path</param>
		public List<Tile> CreateNewPath(Tile origin, Tile target)
		{
			var oPos = origin.transform.position;
			var tPos = target.transform.position;
			
			_openNodes = new Heap<PathNode>(127);
			_closedNodes = new HashSet<PathNode>();
			_originTile = origin;
			_targetTile = target;
			_originNode = new PathNode(true, CalculateDistance(oPos, tPos), origin);
			_targetNode = new PathNode(false, CalculateDistance(oPos, tPos), target);

			_openNodes.Add(_originNode);

			ScanArea();

			if (_noPathCount == 4) return null;
			
			RetracePath(_originNode, _targetNode);

			return _path;
		}

		private void ScanArea()
		{
			while (_openNodes.Count > 0)
			{
				var scanningNode = _openNodes.RemoveFirst();
				_closedNodes.Add(scanningNode);

				if (scanningNode.IsTarget)
				{
					_targetNode = scanningNode;
					break;
				}
				
				if (!scanningNode.IsPathable)
					continue;

				var adjacentTiles = scanningNode.Tile.GetAdjacentTiles();

				_noPathCount = 0;
				for (var i = 0; i < 4; i++)
				{
					var tile = adjacentTiles[i];

					if (tile == null || !tile.GetIsWalkable() || NodeInClosedNodes(tile))
					{
						_noPathCount++;
						continue;
					}

					if (!NodeInOpenNodes(tile))
					{
						var newNode = CreateNewPathNode(tile);
						scanningNode.SetNeighbor(i, newNode);
						_openNodes.Add(newNode);
						
						if (newNode.Tile.transform.position == _targetNode.Tile.transform.position)
							newNode.IsTarget = true;
					}
				}

				if (_noPathCount == 4)
				{
					scanningNode.IsPathable = false;
					scanningNode.Parent = null;
				}
			}
		}
		
		/// <summary>Returns the distance in steps from the start to the end.</summary>
		private int CalculateDistance(Vector3 start, Vector3 end)
		{
			var ax = start.x;
			var az = start.z;
			var bx = end.x;
			var bz = end.z;

			int Compare(float a, float b)
			{
				if (a * b > 0)
					return (int) Mathf.Abs(a - b);
				return (int) Mathf.Abs(a + b);
			}

			return Compare(ax, bx) + Compare(az, bz);
		}

		private void RetracePath(PathNode start, PathNode target)
		{
			var node = target;
			var path = new List<Tile>();
			
			while (node != start)
			{
				path.Add(node.Tile);
				node = node.Parent;
			}

			path.Reverse();
			_path = path;
		}

		private PathNode CreateNewPathNode(Tile tile)
		{
			return new PathNode(CalculateDistance(_originTile.transform.position, tile.transform.position),
				CalculateDistance(tile.transform.position, _targetTile.transform.position), tile);
		}

		private bool NodeInOpenNodes(Tile tile)
		{
			for (var i = 0; i < _openNodes.Count; i++)
			{
				if (_openNodes.GetElement(i).Tile.transform.position == tile.transform.position)
					return true;
			}
			
			return false;
		}

		private bool NodeInClosedNodes(Tile tile)
		{
			if (_closedNodes.Count < 1)
				return false;

			foreach (var node in _closedNodes)
			{
				if (node.Tile.transform.position == tile.transform.position) return true;
			}

			return false;
		}
	}
}