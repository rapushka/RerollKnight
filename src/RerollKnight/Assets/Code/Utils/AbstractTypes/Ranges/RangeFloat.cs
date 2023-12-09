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

		public static RangeFloat FromCenterAndWidth(float center, float width)
			=> FromCenterAndRadius(center, width * 0.5f);

		public static RangeFloat FromCenterAndRadius(float center, float radius)
			=> new(center - radius, center + radius);

		public float Delta => Max.Delta(Min);
	}
}