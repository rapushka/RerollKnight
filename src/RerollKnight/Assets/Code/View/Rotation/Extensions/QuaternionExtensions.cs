using UnityEngine;

namespace Code
{
	public static class QuaternionExtensions
	{
		public static float AngleTo(this Quaternion @this, Quaternion other)
			=> Quaternion.Angle(@this, other);
	}
}