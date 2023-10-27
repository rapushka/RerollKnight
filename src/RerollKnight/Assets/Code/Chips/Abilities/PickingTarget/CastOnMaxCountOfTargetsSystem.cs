using System.Collections.Generic;
using System.Linq;
using Entitas;
using static ChipsMatcher;
using static GameMatcher;

namespace Code
{
	public sealed class CastOnMaxCountOfTargetsSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _targets;
		private readonly IGroup<ChipsEntity> _abilities;

		public CastOnMaxCountOfTargetsSystem(Contexts contexts)
		{
			_targets = contexts.game.GetGroup(PickedTarget);
			_abilities = contexts.chips.GetGroup(AllOf(State, MaxCountOfTargets));
		}

		private IEnumerable<ChipsEntity> FilledAbilities
			=> _abilities.GetEntities().Where((e) => e.maxCountOfTargets.Value == _targets.count);

		public void Execute()
		{
			foreach (var e in FilledAbilities.Where((e) => e.state.Value is AbilityState.Prepared))
			{
				e.ReplaceState(AbilityState.Casting);
				ServicesMediator.GameStateMachine.ToState<WaitingGameState>();
			}
		}
	}
}