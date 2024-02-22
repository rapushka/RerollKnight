using UnityEngine;
using static System.Single;

namespace Code
{
	public static class QuaternionExtensions
	{
		public static float AngleTo(this Quaternion @this, Quaternion other)
			=> Quaternion.Angle(@this, other);

		public static Quaternion SetEuler(this Quaternion @this, float x = NaN, float y = NaN, float z = NaN)
		{
			var euler = @this.eulerAngles;

			if (!IsNaN(x))
				euler.x = x;

			if (!IsNaN(y))
				euler.y = y;

			if (!IsNaN(z))
				euler.z = z;

			return Quaternion.Euler(euler);
		}
	}
}