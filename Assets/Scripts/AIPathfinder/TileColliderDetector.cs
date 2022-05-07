using UnityEngine;

public class TileColliderDetector : MonoBehaviour
{
    private Tile[] _tiles = new Tile[4];

    private void Awake()
    {
        _tiles = new Tile[] {null, null, null, null};
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FloorTile"))
        {
            if (other.transform.position.z > transform.position.z)
                _tiles[0] = other.GetComponentInParent<Tile>();
            else if (other.transform.position.x > transform.position.x)
                _tiles[1] = other.GetComponentInParent<Tile>();
            else if (other.transform.position.z < transform.position.z)
                _tiles[2] = other.GetComponentInParent<Tile>();
            else if (other.transform.position.x < transform.position.x)
                _tiles[3] = other.GetComponentInParent<Tile>();
        }
    }

    public Tile[] GetTileCollisions()
    {
        return _tiles;
    }
}