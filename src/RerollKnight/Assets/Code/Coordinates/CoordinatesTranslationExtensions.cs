using UnityEngine;

namespace Code
{
	public static class CoordinatesTranslationExtensions
	{
		public static Vector3 ToWorldPoint(this Coordinates @this)
		{
			const float overFieldOffset = 0.125f; // TODO: Ripped out from the View Config

			var position = @this.ToTopDown();

			if (@this.OnLayer is Coordinates.Layer.Default)
			{
				position += Vector3.up * overFieldOffset;
			}

			return position;
		}
	}
}