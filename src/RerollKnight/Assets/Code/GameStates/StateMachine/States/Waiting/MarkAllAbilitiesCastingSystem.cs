using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class MarkAllAbilitiesCastingSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<ChipsScope>> _abilities = Contexts.Instance.GetGroup(Get<Component.State>());

		private IEnumerable<Entity<ChipsScope>> PreparedAbilities => _abilities.WhereStateIs(AbilityState.Prepared);

		public void Initialize()
		{
			foreach (var ability in PreparedAbilities)
				ability.Replace<Component.State, AbilityState>(AbilityState.Casting);
		}
	}
}