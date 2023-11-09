using System.Linq;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class MarkUnavailableByComponentsSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _targets;
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		[Inject]
		public MarkUnavailableByComponentsSystem(Contexts contexts)
		{
			_targets = contexts.GetGroup(ScopeMatcher<GameScope>.Get<AvailableToPick>());
			_abilities = contexts.GetGroup(AllOf(Get<TargetConstraints>(), Get<State>()));
		}

		public void Execute()
		{
			foreach (var ability in _abilities.WhereStateIs(AbilityState.Prepared))
			foreach (var target in _targets.GetEntities())
			{
				if (ability.Get<TargetConstraints>().Value.Any((c) => !target.HasComponent(c.Index)))
					target.Is<AvailableToPick>(false);
			}
		}
	}
}