using System.Collections.Generic;
using System.Linq;
using Entitas;
using JetBrains.Annotations;

namespace Code
{
	public static class RandomExtensions
	{
		public static T PickRandom<T>(this IEnumerable<T> @this)
			where T : class, IEntity
		{
			var array = @this as T[] ?? @this.ToArray();
			return array.PickRandom();
		}

		[CanBeNull]
		public static T PickRandomOrDefault<T>(this IGroup<T> @this)
			where T : class, IEntity
			=> @this.Any() ? default : @this.PickRandom();

		public static T PickRandom<T>(this IGroup<T> @this)
			where T : class, IEntity
			=> @this.GetEntities().PickRandom();

		public static T PickRandom<T>(this T[] @this) => @this[@this.RandomIndex()];

		public static int RandomIndex<T>(this T[] @this) => RandomService.Instance.Range(0, @this.Length);
	}
}