using Creatures.Player;
using Player;
using UnityEngine;

public class SetCreaturePosition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FloorTile"))
            if (transform.parent.CompareTag("Player"))
                GetComponentInParent<PlayerMovement>().SetPosition(other.transform.GetComponent<Tile>());
            else if (transform.parent.CompareTag("Enemy"))
                GetComponentInParent<EnemyBehaviorTileBased>().SetPosition(other.transform.GetComponent<Tile>());
    }
}