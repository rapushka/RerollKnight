using System;
using System.Collections.Generic;

namespace Code.Workflow.Extensions
{
	public static class CollectionsExtensions
	{
		public static void ForEach<T>(this T[] @this, Action<T> action) => Array.ForEach(@this, action);

		public static void ForEach<T>(this HashSet<T> @this, Action<T> action)
		{
			foreach (T t in @this)
			{
				action.Invoke(t);
			}
		}

		public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
		{
			foreach (T t in @this)
			{
				action.Invoke(t);
			}
		}
	}
}