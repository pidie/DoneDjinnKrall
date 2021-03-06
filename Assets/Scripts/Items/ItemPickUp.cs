using Inventory;
using UnityEngine;

namespace Items
{
    public class ItemPickUp : MonoBehaviour
    {
        [SerializeField] private Item item;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                InventoryCollection.Instance.AddItem(item);
                Destroy(gameObject);
            }
        }
    }
}
