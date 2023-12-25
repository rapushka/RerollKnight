using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class MarkAllAbilitiesCastingSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		[Inject]
		public MarkAllAbilitiesCastingSystem(Contexts contexts)
		{
			_abilities = contexts.GetGroup(Get<Component.AbilityState>());
		}

		private IEnumerable<Entity<ChipsScope>> PreparedAbilities => _abilities.WhereStateIs(AbilityState.Prepared);

		public void Initialize()
		{
			foreach (var ability in PreparedAbilities)
				ability.Replace<Component.AbilityState, AbilityState>(AbilityState.Casting);
		}
	}
}