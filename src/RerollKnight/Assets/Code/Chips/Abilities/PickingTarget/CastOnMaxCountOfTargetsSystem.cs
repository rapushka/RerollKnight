using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class CastOnMaxCountOfTargetsSystem : IExecuteSystem, IStateTransferSystem
	{
		private readonly IGroup<Entity<GameScope>> _targets;
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		public CastOnMaxCountOfTargetsSystem(Contexts contexts)
		{
			_targets = contexts.GetGroup(GameMatcher.Get<PickedTarget>());
			_abilities = contexts.GetGroup(AllOf(Get<Component.AbilityState>(), Get<MaxCountOfTargets>()));
		}

		public StateMachineBase StateMachine { get; set; }

		private IEnumerable<Entity<ChipsScope>> FilledAbilities
			=> _abilities.GetEntities().Where((e) => e.Get<MaxCountOfTargets>().Value == _targets.count);

		public void Execute()
		{
			if (FilledAbilities.WhereStateIs(AbilityState.Prepared).Any())
				StateMachine.ToState<StartCastAnimationGameplayState>();
		}
	}
}