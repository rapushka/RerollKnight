using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public static class AbilityStateExtensions
	{
		public static IEnumerable<Entity<TScope>> WhereStateIs<TScope>
			(this IGroup<Entity<TScope>> @this, AbilityState state)
			where TScope : IScope
			=> @this.Where((e) => e.Get<Component.AbilityState>().Value == state);

		public static IEnumerable<Entity<TScope>> WhereStateIs<TScope>
			(this IEnumerable<Entity<TScope>> @this, AbilityState state)
			where TScope : IScope
			=> @this.Where((e) => e.Get<Component.AbilityState>().Value == state);

		public static IEnumerable<Entity<TScope>> WhereStateIsNot<TScope>
			(this IGroup<Entity<TScope>> @this, AbilityState state)
			where TScope : IScope
			=> @this.Where((e) => e.Get<Component.AbilityState>().Value != state);

		public static IEnumerable<Entity<TScope>> WhereStateIsNot<TScope>
			(this IEnumerable<Entity<TScope>> @this, AbilityState state)
			where TScope : IScope
			=> @this.Where((e) => e.Get<Component.AbilityState>().Value != state);
	}
}