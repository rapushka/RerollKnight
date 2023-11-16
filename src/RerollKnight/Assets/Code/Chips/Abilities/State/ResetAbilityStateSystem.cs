using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class ResetAbilityStateSystem : ITearDownSystem
	{
		private readonly IGroup<Entity<ChipsScope>> _entities;

		public ResetAbilityStateSystem(Contexts contexts)
			=> _entities = contexts.Get<ChipsScope>().GetGroup(Get<Component.AbilityState>());

		public void TearDown()
		{
			foreach (var e in _entities.WhereStateIs(AbilityState.Casted))
				e.Replace<Component.AbilityState, AbilityState>(AbilityState.Inactive);
		}
	}
}