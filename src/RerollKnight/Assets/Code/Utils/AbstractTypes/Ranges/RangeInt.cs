using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public struct RangeInt : IRange<int>
	{
		[field: SerializeField] public int Min { get; set; }
		[field: SerializeField] public int Max { get; set; }

		public RangeInt(int min, int max)
		{
			Min = min;
			Max = max;
		}

		public int Delta => Max - Min;
	}
}