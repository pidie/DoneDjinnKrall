using System;
using System.Collections;
using AIPathfinder;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehaviorTileBased : MonoBehaviour
{
    [SerializeField] private PlayerData player;
    [SerializeField] private int damage;
    [SerializeField] private float updateSpeed;
    [SerializeField] private float attackCooldown;
    
    private bool _resting;
    private bool _attackCoolingdown;
    private Vector3 _pos;
    private Vector3 _playerPos;
    private float _xDistance;
    private float _zDistance;
    private Tile _position;
    private Pathfinder _pathfinder;

    private void Awake() => _pathfinder = GameObject.Find("Pathfinder").GetComponent<Pathfinder>();
    
    private void Update()
    {
        _playerPos = player.transform.position;
        _pos = transform.position;
        
        var highX = Math.Max(_pos.x, _playerPos.x);
        var lowX = Math.Min(_pos.x, _playerPos.x);
        var highZ = Math.Max(_pos.z, _playerPos.z);
        var lowZ = Math.Min(_pos.z, _playerPos.z);

        _xDistance = highX - lowX;
        _zDistance = highZ - lowZ;

        transform.position = new Vector3(_pos.x, _position.transform.position.y + 1.5f, _pos.z);
        
        if (_resting)
            return;
        
        if (IsAdjacentToPlayer())
            Attack();
        else
            MoveToPlayer();

        _resting = true;
        StartCoroutine(Rest());
    }

    public void SetPosition(Tile tile)
    {
        _position = tile;
    }

    public Tile GetPosition()
    {
        return _position;
    }

    private bool IsAdjacentToPlayer()
    {
        return (_xDistance == 0 && _zDistance == 2f) || (_zDistance == 0 && _xDistance == 2f);
    }

    private void Attack()
    {
        if (!_attackCoolingdown)
        {
            player.TakeDamage(damage);
            _attackCoolingdown = true;
            StartCoroutine(AttackCooldown());
        }
    }

    private void MoveToPlayer()
    {
        // todo : integrate pathfinder
        // var newPosition = _pathfinder.CreateNewPath(_position, player.GetComponent<PlayerMovement>().GetPosition());
        // newPosition?[0].SetCreaturePosition(transform);

        if (_xDistance > _zDistance)
        {
            TryMoveToTile(_playerPos.x > _pos.x ? 1 : 3);
        }
        else
        {
            TryMoveToTile(_playerPos.z > _pos.z ? 0 : 2);
        }

        void TryMoveToTile(int index)
        {
            var target = _position.GetAdjacentTiles()[index];
            
            if (target != null)
            {
                if (!target.GetIsWalkable())
                {
                    var val = Random.Range(0, 2);
                    var _ = val - .5f;
                    _ *= 2;
                    val = (int) _;

                    if (val + index < 0)
                        _position.GetAdjacentTiles()[3].SetCreaturePosition(transform);
                    else if (val + index > 3)
                        _position.GetAdjacentTiles()[0].SetCreaturePosition(transform);
                    else
                        _position.GetAdjacentTiles()[index + val].SetCreaturePosition(transform);
                }
                else 
                    _position.GetAdjacentTiles()[index].SetCreaturePosition(transform);
            }
        }
    }

    private IEnumerator Rest()
    {
        yield return new WaitForSeconds(updateSpeed);
        _resting = false;
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        _attackCoolingdown = false;
    }
}