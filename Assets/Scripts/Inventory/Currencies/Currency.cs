using System;
using UnityEngine;

namespace Inventory.Currencies
{
	public abstract class Currency : ScriptableObject
	{
		protected int quantity;

		public int Quantity => quantity;

		public CurrencyData currencyData { get; protected set; }

		protected Currency() => quantity = 0;
		protected Currency(int value) => quantity = value;

		public void Bind(CurrencyData data) => currencyData = data;
	}

	public abstract class Currency<T> : Currency where T : IAccruable
	{
		public static Currency<T> operator +(Currency<T> a, Currency<T> b)
		{
			a.quantity = a.Quantity + b.Quantity;
			return a;
		}

		public static Currency<T> operator -(Currency<T> a, Currency<T> b)
		{
			a.quantity = a.Quantity - b.Quantity;
			return a;
		}

		public static Currency<T> operator *(Currency<T> a, Currency<T> b)
		{
			a.quantity = a.Quantity * b.Quantity;
			return a;
		}

		/// <summary> THIS OPERATOR WILL AUTOMATICALLY ROUND TO THE NEAREST EVEN INTEGER </summary>
		public static Currency<T> operator /(Currency<T> a, Currency<T> b)
		{
			a.quantity = (int) Mathf.Round(a.Quantity / b.Quantity);
			return a;
		}
		
		// public static Currency<T> operator +(Currency<T> a, Currency<T> b) => new Currency<T>(a.Quantity + b.Quantity);
		// public static Currency<T> operator -(Currency<T> a, Currency<T> b) => new Currency<T>(a.Quantity - b.Quantity); 
		// public static Currency<T> operator *(Currency<T> a, Currency<T> b) => new Currency<T>(a.Quantity * b.Quantity);
		// public static Currency<T> operator /(Currency<T> a, Currency<T> b) => new Currency<T>((int) Mathf.Round(a.Quantity / b.Quantity));
	}

	[Serializable]
	public class CurrencyData
	{
		public string name;
		public string value;
	}
}