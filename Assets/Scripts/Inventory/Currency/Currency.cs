using UnityEngine;

namespace Inventory.Currency
{
    public abstract class Currency : ScriptableObject
    {
        protected int value;
    }

    public abstract class Currency<T> : Currency where T : Currency<T>
    {
        
    }
}