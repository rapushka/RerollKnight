using UnityEngine;
using static System.Single;

namespace Code
{
	public static class VectorExtensions
	{
		public static float DistanceTo(this Vector3 @this, Vector3 other)
			=> Vector3.Distance(@this, other);

		public static Vector3 Add(this Vector3 @this, float x = 0f, float y = 0f, float z = 0f)
			=> new(@this.x + x, @this.y + y, @this.z + z);

		public static Vector3 Set(this Vector3 @this, float x = NaN, float y = NaN, float z = NaN)
		{
			if (!IsNaN(x))
				@this.x = x;

			if (!IsNaN(y))
				@this.y = y;

			if (!IsNaN(z))
				@this.z = z;

			return @this;
		}
	}
}