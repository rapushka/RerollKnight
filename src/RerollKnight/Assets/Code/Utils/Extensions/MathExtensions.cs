using UnityEngine;

namespace Code
{
	public static class MathExtensions
	{
		public static int Clamp(this int @this, int min = int.MinValue, int max = int.MaxValue)
		{
			@this = Mathf.Max(@this, min);
			@this = Mathf.Min(@this, max);
			return @this;
		}
	}
}