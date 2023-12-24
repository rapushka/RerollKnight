using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class MarkAllAbilitiesCastedSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		[Inject]
		public MarkAllAbilitiesCastedSystem(Contexts contexts)
		{
			_abilities = contexts.GetGroup(ScopeMatcher<ChipsScope>.Get<Component.AbilityState>());
		}

		private IEnumerable<Entity<ChipsScope>> PreparedAbilities => _abilities.WhereStateIs(AbilityState.Prepared);

		public void Initialize()
		{
			foreach (var ability in PreparedAbilities)
				ability.Replace<Component.AbilityState, AbilityState>(AbilityState.Casted);
		}
	}
}