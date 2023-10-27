using System.Collections.Generic;
using Entitas;
using static ChipsMatcher;

namespace Code
{
	public class WaitingGameState : GameStateBase
	{
		private readonly IGroup<ChipsEntity> _abilities;

		public WaitingGameState(GameStateMachine stateMachine) : base(stateMachine)
			=> _abilities = Contexts.sharedInstance.chips.GetGroup(State);

		private IEnumerable<ChipsEntity> PreparedAbilities => _abilities.WhereStateIs(AbilityState.Prepared);

		public override void Enter()
		{
			foreach (var ability in PreparedAbilities)
				ability.ReplaceState(AbilityState.Casting);
		}
	}
}