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

		public static T[] Add<T>(this T[] @this, T item)
		{
			Array.Resize(ref @this, @this.Length + 1);
			@this[^1] = item;
			return @this;
		}

		public static void RemoveLast<T>(this T[] @this)
			=> Array.Resize(ref @this, @this.Length - 1);
	}
}