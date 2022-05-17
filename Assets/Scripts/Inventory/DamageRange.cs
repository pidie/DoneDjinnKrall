using System;
using UnityEngine;

namespace Inventory
{
	[Serializable]
	public class DamageRange
	{
		[SerializeField] private int min, max;

		public DamageRange Get => new DamageRange(min, max);
		public int Damage => UnityEngine.Random.Range(min, max + 1);

		public DamageRange(int value)
		{
			if (Validate(value))
			{
				min = value;
				max = value;
			}
		}
		public DamageRange(int min, int max)
		{
			if (Validate(min, max))
			{
				this.min = min;
				this.max = max;
			}
		}

		public void Set(int min, int max)
		{
			if (Validate(min, max))
			{
				this.min = min;
				this.max = max;
			}
		}
		public void Set(DamageRange damageRange)
		{
			if (Validate(min, max))
			{
				this.min = damageRange.Get.min;
				this.max = damageRange.Get.max;
			}
		}

		public DamageRange Modify(int newMin, int newMax) => new DamageRange(min + newMin, max + newMax);
		public DamageRange ModifyMin(int newMin) => new DamageRange(min + newMin, max);
		public DamageRange ModifyMax(int newMax) => new DamageRange(min, newMax + max);

		public static DamageRange operator +(DamageRange a, DamageRange b) => new DamageRange(a.min + b.min, a.max + b.max);
		public static DamageRange operator -(DamageRange a, DamageRange b) => new DamageRange(a.min - b.min, a.max - b.max);

		private bool Validate(int value)
		{
			if (value < 0)
				throw new ArgumentOutOfRangeException(nameof(value));
			
			return true;
		}
		private bool Validate(int min, int max)
		{
			if (min < 0) throw new ArgumentOutOfRangeException(nameof(min));
			if (max < 0) throw new ArgumentOutOfRangeException(nameof(max));
			if (min > max) throw new InvalidOperationException(
				$"The minimum value ({min}) cannot be greater than the maximum value ({max}).");

			return true;
		}
	}
}