using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Workflow.Extensions
{
	public static class CollectionsExtensions
	{
		public static T PickRandom<T>(this IEnumerable<T> @this)
		{
			T[] enumerable = @this as T[] ?? @this.ToArray();
			return enumerable[Random.Range(0, enumerable.Length)];
		}
	}
}