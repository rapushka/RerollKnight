using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class AddAbilityStateSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<ChipsScope>> _entities;

		public AddAbilityStateSystem(Contexts contexts)
			=> _entities = contexts.Get<ChipsScope>().GetGroup(AllOf(Get<AbilityOfChip>()).NoneOf(Get<State>()));

		public void Initialize()
		{
			foreach (var e in _entities.GetEntities())
				e.Replace<State, AbilityState>(AbilityState.Inactive);
		}
	}
}