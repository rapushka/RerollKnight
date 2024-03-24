using System;
using JetBrains.Annotations;

namespace Code
{
	public static class ArrayExtensions
	{
		public static int IndexOf<T>(this T[] @this, T item, bool clamped = false)
		{
			var indexOf = Array.IndexOf(@this, item);
			return clamped ? indexOf.Clamp(min: 0) : indexOf;
		}

		[Pure]
		public static T[] Add<T>(this T[] @this, T item)
		{
			Array.Resize(ref @this, @this.Length + 1);
			@this[^1] = item;
			return @this;
		}

		[Pure]
		public static T[] RemoveAt<T>(this T[] @this, int index)
		{
			for (var i = index; i < @this.Length - 1; i++)
				@this[i] = @this[i + 1];

			Array.Resize(ref @this, @this.Length - 1);
			return @this;
		}
	}
}