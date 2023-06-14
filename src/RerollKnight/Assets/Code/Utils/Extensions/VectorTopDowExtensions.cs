using UnityEngine;

namespace Code
{
	public static class VectorTopDowExtensions
	{
		public static Vector3 ToTopDown(this Vector2 @this) => new(@this.x, 0, @this.y);

		public static Vector2 FromTopDown(this Vector3 @this) => new(@this.x, @this.z);
	}
}