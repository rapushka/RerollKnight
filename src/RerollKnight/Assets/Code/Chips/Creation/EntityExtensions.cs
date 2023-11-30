using Entitas.Generic;

namespace Code
{
	public static class EntityExtensions
	{
		public static Entity<ChipsScope> Add<TComponent, TValue>(this Entity<ChipsScope> @this, TValue value, bool @if)
			where TComponent : ValueComponent<TValue>, new()
			=> @this.Add<ChipsScope, TComponent, TValue>(value, @if);

		public static Entity<TScope> Add<TScope, TComponent, TValue>(this Entity<TScope> @this, TValue value, bool @if)
			where TScope : IScope
			where TComponent : ValueComponent<TValue>, new()
		{
			if (@if)
				@this.Add<TComponent, TValue>(value);

			return @this;
		}
	}
}