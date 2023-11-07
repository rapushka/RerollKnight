using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Generic;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class CastOnMaxCountOfTargetsSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _targets;
		private readonly IGroup<Entity<ChipsScope>> _abilities;
		private readonly GameStateMachine _gameStateMachine;

		public CastOnMaxCountOfTargetsSystem(Contexts contexts, GameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;

			_targets = contexts.GetGroup(GameMatcher.Get<PickedTarget>());
			_abilities = contexts.GetGroup(AllOf(Get<State>(), Get<MaxCountOfTargets>()));
		}

		private IEnumerable<Entity<ChipsScope>> FilledAbilities
			=> _abilities.GetEntities().Where((e) => e.Get<MaxCountOfTargets>().Value == _targets.count);

		public void Execute()
		{
			foreach (var e in FilledAbilities.Where((e) => e.Get<State>().Value is AbilityState.Prepared))
			{
				e.Replace<State, AbilityState>(AbilityState.Casting);
				_gameStateMachine.ToState<WaitingGameState>();
			}
		}
	}
}