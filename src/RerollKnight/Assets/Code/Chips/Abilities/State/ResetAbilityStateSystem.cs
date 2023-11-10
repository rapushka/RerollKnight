using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class ResetAbilityStateSystem : ICleanupSystem
	{
		private readonly IGroup<Entity<ChipsScope>> _entities;

		public ResetAbilityStateSystem(Contexts contexts)
			=> _entities = contexts.Get<ChipsScope>().GetGroup(Get<State>());

		public void Cleanup()
		{
			foreach (var e in _entities.WhereStateIs(AbilityState.Casted))
				e.Replace<State, AbilityState>(AbilityState.Inactive);
		}
	}
}