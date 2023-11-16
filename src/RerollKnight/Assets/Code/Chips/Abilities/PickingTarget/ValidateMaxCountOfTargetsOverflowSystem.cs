using System;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class ValidateMaxCountOfTargetsOverflowSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _targets;
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		public ValidateMaxCountOfTargetsOverflowSystem(Contexts contexts)
		{
			_targets = contexts.GetGroup(GameMatcher.Get<PickedTarget>());
			_abilities = contexts.GetGroup(AllOf(Get<Component.AbilityState>(), Get<MaxCountOfTargets>()));
		}

		private int TargetsCount => _targets.count;

		public void Execute()
		{
			if (_abilities.WhereStateIs(AbilityState.Prepared).Any(EnoughPickedTargets))
				throw new InvalidOperationException("Too many targets for the ability");
		}

		private bool EnoughPickedTargets(Entity<ChipsScope> entity)
			=> TargetsCount > entity.Get<MaxCountOfTargets>().Value;
	}
}