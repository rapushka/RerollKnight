using System.Collections.Generic;
using Entitas;

namespace Code
{
	public static class AbilityStateExtensions
	{
		public static IEnumerable<ChipsEntity> WhereStateIs(this IGroup<ChipsEntity> @this, AbilityState state)
			=> @this.Where((e) => e.state.Value == state);

		public static IEnumerable<ChipsEntity> WhereStateIsNot(this IGroup<ChipsEntity> @this, AbilityState state)
			=> @this.Where((e) => e.state.Value == state);
	}
}