using UnityEngine;

namespace Inventory.Currencies
{
	public abstract class Currency : ScriptableObject
	{
		protected int quantity;

		public int Quantity => quantity;

		public CurrencyData currencyData { get; private set; }

		protected Currency() => quantity = 0;
		public Currency(int value) => quantity = value;

		public void Bind(CurrencyData data) => currencyData = data;
	}

	public abstract class Currency<T> : Currency where T : IAccruable
	{
		// public static Currency<T> operator +(Currency<T> a, Currency<T> b) => new Currency<T>(a.Quantity + b.Quantity);
		// public static Currency<T> operator -(Currency<T> a, Currency<T> b) => new Currency<T>(a.Quantity - b.Quantity); 
		// public static Currency<T> operator *(Currency<T> a, Currency<T> b) => new Currency<T>(a.Quantity * b.Quantity);
		// public static Currency<T> operator /(Currency<T> a, Currency<T> b) => new Currency<T>((int) Mathf.Round(a.Quantity / b.Quantity));
	}

	public class CurrencyData
	{
		public string name;
		public string value;
	}
}