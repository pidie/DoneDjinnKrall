using UnityEngine;

namespace Inventory.Currency
{
    public abstract class Currency : ScriptableObject
    {
        protected int quantity;

        public int Quantity => quantity;

        public Currency() => quantity = 0;
        public Currency(int value) => quantity = value;
    }

    public abstract class Currency<T> : Currency where T : IAccruable
    {
        public override Currency<T> operator +(Currency<T> a, Currency<T> b) => new Currency<T>(a.Quantity + b.Quantity);
        public override Currency<T> operator -(Currency<T> a, Currency<T> b) => new Currency<T>(a.Quantity - b.Quantity); 
        public override Currency<T> operator *(Currency<T> a, Currency<T> b) => new Currency<T>(a.Quantity * b.Quantity);
        public override Currency<T> operator /(Currency<T> a, Currency<T> b) => new Currency<T>((int) Mathf.Round(a.Quantity / b.Quantity));
    }
}