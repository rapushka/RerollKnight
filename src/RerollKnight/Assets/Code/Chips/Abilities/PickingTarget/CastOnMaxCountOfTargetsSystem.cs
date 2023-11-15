using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class CastOnMaxCountOfTargetsSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _targets;
		private readonly IGroup<Entity<ChipsScope>> _abilities;
		private readonly IStateChangeBus _stateChangeBus;

		public CastOnMaxCountOfTargetsSystem(Contexts contexts, IStateChangeBus stateChangeBus)
		{
			_stateChangeBus = stateChangeBus;

			_targets = contexts.GetGroup(GameMatcher.Get<PickedTarget>());
			_abilities = contexts.GetGroup(AllOf(Get<Component.AbilityState>(), Get<MaxCountOfTargets>()));
		}

		private IEnumerable<Entity<ChipsScope>> FilledAbilities
			=> _abilities.GetEntities().Where((e) => e.Get<MaxCountOfTargets>().Value == _targets.count);

		public void Execute()
		{
			foreach (var e in FilledAbilities.WhereStateIs(AbilityState.Prepared))
			{
				// TODO: why casting's here and in MarkAllAbilitiesCastingSystem?
				e.Replace<Component.AbilityState, AbilityState>(AbilityState.Casting);
				_stateChangeBus.ToState<WaitingGameState>();
			}
		}
	}
}