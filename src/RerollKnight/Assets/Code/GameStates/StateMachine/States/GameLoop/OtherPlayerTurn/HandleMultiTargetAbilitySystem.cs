using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class HandleMultiTargetAbilitySystem : IInitializeSystem
	{
		private readonly IGroup<Entity<ChipsScope>> _abilities;
		private readonly IGroup<Entity<GameScope>> _targets;

		public HandleMultiTargetAbilitySystem(Contexts contexts)
		{
			_abilities = contexts.GetGroup(ScopeMatcher<ChipsScope>.Get<Component.AbilityState>());
			_targets = contexts.GetGroup(AllOf(Get<Target>(), Get<AvailableToPick>()).NoneOf(Get<PickedTarget>()));
		}

		private IEnumerable<Entity<ChipsScope>> PreparedAbilities => _abilities.WhereStateIs(AbilityState.Prepared);

		public void Initialize()
		{
			if (!PreparedAbilities.Any())
				return;

			var maxTargetsCount = PreparedAbilities.Max((a) => a.Get<MaxCountOfTargets>().Value);
			if (maxTargetsCount > 1)
			{
				// starts from 1, because we already have one picked target
				for (var i = 1; i < maxTargetsCount; i++)
					_targets.PickRandom().Pick();
			}
		}
	}
}