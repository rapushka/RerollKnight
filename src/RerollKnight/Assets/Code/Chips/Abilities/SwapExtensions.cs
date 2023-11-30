using Entitas.Generic;

namespace Code
{
	public static class SwapExtensions
	{
		public static void Swap<TComponent, TValue>(this Entity<GameScope> @this, Entity<GameScope> with)
			where TComponent : PrimaryIndexComponent<GameScope, TComponent, TValue>, new()
			=> @this.Swap<GameScope, TComponent, TValue>(with);

		public static void Swap<TScope, TComponent, TValue>(this Entity<TScope> @this, Entity<TScope> with)
			where TScope : IScope
			where TComponent : PrimaryIndexComponent<TScope, TComponent, TValue>, new()
		{
			var value1 = @this.Get<TComponent>().Value;
			var value2 = with.Get<TComponent>().Value;

			@this.Remove<TComponent>();
			with.Remove<TComponent>();

			@this.Replace<TComponent, TValue>(value2);
			with.Replace<TComponent, TValue>(value1);
		}
	}
}