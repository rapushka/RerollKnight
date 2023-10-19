using System;
using Entitas;

namespace Code
{
	public static class EntitasLinqExtension
	{
		public static void ForEach<T>(this IGroup<T> @this, Action<T> @do)
			where T : class, IEntity
		{
			foreach (var entity in @this)
			{
				@do.Invoke(entity);
			}
		}

		public static bool Any<T>(this IGroup<T> @this)
			where T : class, IEntity
			=> @this.Any((_) => true);

		public static bool Any<T>(this IGroup<T> @this, Func<T, bool> predicate)
			where T : class, IEntity
		{
			foreach (var entity in @this)
			{
				if (predicate.Invoke(entity))
				{
					return true;
				}
			}

			return false;
		}

		public static bool All<T>(this IGroup<T> @this, Func<T, bool> predicate)
			where T : class, IEntity
		{
			foreach (var entity in @this)
			{
				if (predicate.Invoke(entity) == false)
				{
					return false;
				}
			}

			return true;
		}
	}
}