using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using ChipsEntity = Entitas.Generic.Entity<Code.ChipsScope>;

namespace Code
{
	public static class AbilityStateExtensions
	{
		public static IEnumerable<Entity<TScope>> WhereStateIs<TScope>
			(this IGroup<Entity<TScope>> @this, AbilityState state)
			where TScope : IScope
			=> @this.Where((e) => e.Get<State>().Value == state);

		public static IEnumerable<Entity<TScope>> WhereStateIsNot<TScope>
			(this IGroup<Entity<TScope>> @this, AbilityState state)
			where TScope : IScope
			=> @this.Where((e) => e.Get<State>().Value != state);
	}
}