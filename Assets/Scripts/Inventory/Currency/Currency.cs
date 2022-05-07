using UnityEngine;

namespace Inventory.Currency
{
    public abstract class Currency : MonoBehaviour, ICollectable
    {
        protected int value;

        protected void OnPickUp() => HandlePickUp();

        protected virtual void HandlePickUp()
        {
            
        }
    }

    interface ICollectable
    {
        protected void OnPickUp();
    }
}