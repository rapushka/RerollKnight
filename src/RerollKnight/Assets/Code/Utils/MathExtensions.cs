using System;

namespace Code
{
	public static class MathExtensions
	{
		public static int Delta(this int @this, int other) => Math.Abs(@this - other);
	}
}