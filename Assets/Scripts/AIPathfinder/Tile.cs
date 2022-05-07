using System.Collections.Generic;
using Creatures;
using Creatures.Player;
using UnityEngine;

public enum TileType
{
    None = 0,
    Grass1 = 10,
    Grass2 = 11,
    StoneDarkGothic = 40
}
public class Tile : MonoBehaviour
{
    [SerializeField] private TileType tileType;
    [SerializeField] private bool isWalkable;

    private bool _isEmpty;
    private bool _isPlayerPosition;
    private bool _isCreaturePosition;
    private MeshRenderer _meshRenderer;
    private Material _material;
    private readonly int _emissionColor = Shader.PropertyToID("_EmissionColor");
    private TileColliderDetector _tileColliderDetector;
    private List<GameObject> _contents;
    private GameObject _host;

    private void Awake()
    {
        var pos = transform.position;
        
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material = Resources.Load<Material>($"Materials/{tileType}");
        _material = _meshRenderer.material;
        _tileColliderDetector = GetComponentInChildren<TileColliderDetector>();
        _isEmpty = true;
        _contents = new List<GameObject>();
        
        if (gameObject.layer != LayerMask.NameToLayer("unwalkable"))
            isWalkable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<CreatureData>())
        {
            _host = other.gameObject;
            _isEmpty = false;
            isWalkable = false;
        }
        
        if (other.CompareTag("Player"))
        {
            EnableTileEmissionColor(Color.green);
            _isPlayerPosition = true;
            _contents.Add(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            EnableTileEmissionColor(Color.red);
            _isCreaturePosition = true;
            _contents.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<CreatureData>())
        {
            DisableTileEmissionColor();
            _host = null;
            _isEmpty = true;
            if (gameObject.layer != LayerMask.NameToLayer("unwalkable"))
                isWalkable = true;
        }
        
        if (other.CompareTag("Player"))
        {
            _isPlayerPosition = false;
            _contents.Remove(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            _isCreaturePosition = false;
            _contents.Remove(other.gameObject);
        }
    }

    private void OnMouseOver()
    {
        if (!_isEmpty)
            return;
        
        EnableTileEmissionColor(Color.yellow);
    }

    private void OnMouseDown()
    {
        if (isWalkable && _isEmpty)
            PlayerMovement.Instance.GetMoveRequest(this);
    }

    private void OnMouseExit()
    {
        if (_isPlayerPosition || _isCreaturePosition)
            return;
        
        DisableTileEmissionColor();
    }

    public List<GameObject> GetContents()
    {
        return _contents;
    }
    
    public Tile[] GetAdjacentTiles()
    {
        return _tileColliderDetector.GetTileCollisions();
    }

    public bool GetIsEmpty()
    {
        return _isEmpty;
    }

    public bool GetIsWalkable()
    {
        return isWalkable;
    }

    public GameObject GetHasHost()
    {
        return _host;
    }

    public void SetCreaturePosition(Transform creature)
    {
        var pos = transform.position;
        creature.position = new Vector3(pos.x, pos.y + 1.5f, pos.z);
    }

    private void EnableTileEmissionColor(Color? color = null)
    {
        if (color != null)
        {
            _material.SetColor(_emissionColor, (Color) color * 2f);
        }
        _material.EnableKeyword("_EMISSION");
    }

    private void DisableTileEmissionColor(Color? color = null)
    {
        if (color != null)
        {
            _material.SetColor(_emissionColor, (Color) color * 2f);
        }
        _material.DisableKeyword("_EMISSION");
    }
}