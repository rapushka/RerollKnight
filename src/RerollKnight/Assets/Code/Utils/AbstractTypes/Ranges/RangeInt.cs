using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public struct RangeInt : IRange<int>
	{
		[field: SerializeField] public int Min { get; set; }
		[field: SerializeField] public int Max { get; set; }

		public RangeInt(int value)
		{
			Min = value;
			Max = value;
		}

		public RangeInt(int min, int max)
		{
			Min = min;
			Max = max;
		}

		public int Delta => Max - Min;

		public bool Contains(int value) => Min <= value && value >= Max;

		public RangeInt Recreate(int value)
		{
			if (value < Min)
				Min = value;

			if (value > Max)
				Max = value;

			return this;
		}

		public override string ToString() => $"{Min} – {Max}";
	}
}