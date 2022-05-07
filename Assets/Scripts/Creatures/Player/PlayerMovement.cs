using System.Collections;
using System.Collections.Generic;
using AIPathfinder;
using UnityEngine;

namespace Creatures.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] [Range(.01f, 1f)] [Tooltip("Directly controls WaitForSeconds()")] private float baseSpeed;
		[SerializeField] private Tile positionTracker;
		[SerializeField] private float playerHeight;

		private bool _moveRequested;
		private bool _isMoving;
		private bool _isDetour;
		private Tile _position;
		private Tile _target;
		private Tile _roadblock;
		private List<Tile> _path;
		private Coroutine _stepToDestination;
		private Pathfinder _pathfinder;
    
		public static PlayerMovement Instance { get; private set; }

		private void Awake()
		{
			if (Instance != null && Instance != this)
				Destroy(Instance);
			else Instance = this;

			_pathfinder = GameObject.Find("Pathfinder").GetComponent<Pathfinder>();
		}

		private void Update()
		{
			if (_moveRequested && _target != _position)
			{
				if (_isMoving)
				{
					if (!_isDetour)
						_path = new List<Tile>();
					
					StopCoroutine(_stepToDestination);
					_isMoving = false;
				}

				_moveRequested = false;
				Move();
			}

			_position = positionTracker;
		}

		public void SetPosition(Tile position) => _position = position;

		public Tile GetPosition()
		{
			return _position;
		}

		public void GetMoveRequest(Tile tile)
		{
			if (tile == _position || tile == _target || !tile.GetIsEmpty())
				return;
	    
			_target = tile;
			_moveRequested = true;
		}

		private void Move()
		{
			_path = _pathfinder.CreateNewPath(_position, _target);
			_stepToDestination = StartCoroutine(StepToDestination(_path));
		}
    
		private IEnumerator StepToDestination(List<Tile> path)
		{
			if (_path == null) yield break;
			
			_isMoving = true;
	    
			foreach (var cell in path)
			{
				if (!cell.GetIsEmpty() && !_isDetour)
				{
					_roadblock = GetRoadblock(cell);

					_path = _pathfinder.CreateNewPath(_position, _roadblock);
					
					StopCoroutine(_stepToDestination);
					_isDetour = true;
					_moveRequested = true;
				}
				else
				{
					cell.SetCreaturePosition(transform);
					positionTracker = cell;
					yield return new WaitForSeconds(baseSpeed);
				}
			}
	    
			_isMoving = false;
			if (_isDetour)
				_isDetour = false;
		}

		private Tile GetRoadblock(Tile cell)
		{
			var cellPos = cell.transform.position;
			var pos = transform.position;
			var direction = new Vector3(cellPos.x, 0, cellPos.z) - new Vector3(pos.x, 0, pos.z);
			direction.Normalize();

			var index = -1;

			if (direction.x == 1)
			{
				index = 0;
			}
			else if (direction.z == 1)
			{
				index = 1;
			}
			else if (direction.x == -1)
			{
				index = 2;
			}
			else
			{
				index = 3;
			}

			return cell.GetAdjacentTiles()[index];
		}
	}
}