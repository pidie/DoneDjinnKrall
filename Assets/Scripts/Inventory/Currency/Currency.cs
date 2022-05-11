using UnityEngine;

namespace Inventory.Currency
{
    public abstract class Currency : ScriptableObject
    {
        protected int quantity;

        public int Quantity => quantity;

        public CurrencyData currencyData { get; private set; }

        public Currency() => quantity = 0;
        public Currency(int value) => quantity = value;

        public Bind(CurrencyData data) => currencyData = data;
    }

    public abstract class Currency<T> : Currency where T : IAccruable
    {
        public override Currency<T> operator +(Currency<T> a, Currency<T> b) => new Currency<T>(a.Quantity + b.Quantity);
        public override Currency<T> operator -(Currency<T> a, Currency<T> b) => new Currency<T>(a.Quantity - b.Quantity); 
        public override Currency<T> operator *(Currency<T> a, Currency<T> b) => new Currency<T>(a.Quantity * b.Quantity);
        public override Currency<T> operator /(Currency<T> a, Currency<T> b) => new Currency<T>((int) Mathf.Round(a.Quantity / b.Quantity));
    }

    public class CurrencyData
    {
        public string name;
        public string value;
    }
}