using UnityEngine;

namespace Code
{
	public static class VectorTopDowExtensions
	{
		public static Vector3 ToTopDown(this Vector2 @this) => new(@this.y, 0, @this.x);

		public static Vector2 FromTopDown(this Vector3 @this) => new(@this.z, @this.x);
	}
}