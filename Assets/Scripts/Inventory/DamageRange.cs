using System;
using UnityEngine;

namespace Inventory
{
	[Serializable]
	public class DamageRange
	{
		[SerializeField] private int min, max;

		public DamageRange(int min, int max)
		{
			if (min < 0) throw new ArgumentOutOfRangeException(nameof(min));
			if (max < 0) throw new ArgumentOutOfRangeException(nameof(max));
			if (min > max)
			{
				var _ = min;
				min = max;
				max = _;
			}
			this.min = min;
			this.max = max;
		}

		public DamageRange Get() => new DamageRange(min, max);

		public void Set(int min, int max)
		{
			this.min = min;
			this.max = max;
		}

		public void Set(DamageRange damageRange)
		{
			min = damageRange.Get().min;
			max = damageRange.Get().max;
		}

		public DamageRange Modify(int newMin, int newMax) => new DamageRange(min + newMin, max + newMax);

		public DamageRange ModifyMin(int newMin) => new DamageRange(min + newMin, max);

		public DamageRange ModifyMax(int newMax) => new DamageRange(min, newMax + max);

		public override DamageRange operator +(DamageRange a, DamageRange b) => new DamageRange(a.min + b.min, a.max + b.max);
		public override DamageRange operator -(DamageRange a, DamageRange b) => new DamageRange(a.min - b.min, a.max - b.max);
	}
}