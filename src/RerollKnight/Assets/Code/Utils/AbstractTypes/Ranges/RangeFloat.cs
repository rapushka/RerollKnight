using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public struct RangeFloat : IRange<float>
	{
		[field: SerializeField] public float Min { get; set; }
		[field: SerializeField] public float Max { get; set; }

		public RangeFloat(float min, float max)
		{
			Min = min;
			Max = max;
		}

		public static RangeFloat FromCenterAndRadius(float center, float radius)
			=> new() { Min = center - radius, Max = center + radius, };

		public float Delta => Max.Delta(Min);
	}
}