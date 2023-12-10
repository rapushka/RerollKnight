using System;
using UnityEngine;

namespace Code
{
	public static class MathExtensions
	{
		public static int Delta(this int @this, int other) => Math.Abs(@this - other);

		public static float Delta(this float @this, float other) => Math.Abs(@this - other);

		public static int Clamp(this int @this, int min = int.MinValue, int max = int.MaxValue)
			=> Math.Clamp(@this, min, max);

		public static int Clamp<T>(this int @this, T[] array)
			=> @this.Clamp(0, array.Length);

		public static bool ApproximatelyEquals(this float @this, float other)
			=> Math.Abs(@this - other) <= Constants.Tolerance;

		public static float Sin(this float @this, float wholeDuration)
			=> Mathf.Sin(@this / wholeDuration * Mathf.PI);
	}
}