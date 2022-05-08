using UnityEngine;

namespace Inventory.Currency
{
    public abstract class Currency : MonoBehaviour, ICollectable
    {
        protected int value;

        public void OnPickUp() => HandlePickUp();

        protected virtual void HandlePickUp()
        {
            
        }
    }

    interface ICollectable
    {
        void OnPickUp();
    }
}