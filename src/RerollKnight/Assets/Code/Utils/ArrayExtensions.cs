using System;

namespace Code
{
	public static class ArrayExtensions
	{
		public static int IndexOf<T>(this T[] @this, T item, bool clamped = false)
		{
			var indexOf = Array.IndexOf(@this, item);
			return clamped ? indexOf.Clamp(min: 0) : indexOf;
		}
	}
}