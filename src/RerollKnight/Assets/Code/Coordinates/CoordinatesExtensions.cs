using System;
using Entitas.Generic;

namespace Code
{
	public static class CoordinatesExtensions
	{
		public static Coordinates GetCoordinates(this Entity<GameScope> @this)
			=> @this.GetSingle<CoordinatesComponent, CoordinatesUnderField, Coordinates>();

		public static TValue GetSingle<T1, T2, TValue>(this Entity<GameScope> @this)
			where T1 : ValueComponent<TValue>, new()
			where T2 : ValueComponent<TValue>, new()
			=> @this.GetSingle<GameScope, T1, T2, TValue>();

		public static TValue GetSingle<TScope, T1, T2, TValue>(this Entity<TScope> @this)
			where TScope : IScope
			where T1 : ValueComponent<TValue>, new()
			where T2 : ValueComponent<TValue>, new()
			=> @this.Has<T1>() && @this.Has<T2>() ? throw BothComponentsException<T1, T2>()
				: @this.Has<T1>()                 ? @this.Get<T1>().Value
				: @this.Has<T2>()                 ? @this.Get<T2>().Value
				                                    : throw HasNoValueException<TValue>();

		private static InvalidOperationException BothComponentsException<T1, T2>()
			=> new($"Entity can't have both {typeof(T1).Name} and {typeof(T2).Name}");

		private static InvalidOperationException HasNoValueException<TValue>()
			=> new($"Entity has no {typeof(TValue).Name}");
	}
}