using Entitas;
using static ChipsMatcher;

namespace Code
{
	public sealed class EndTurnSystem : ICleanupSystem
	{
		private readonly IGroup<ChipsEntity> _abilities;

		public EndTurnSystem(Contexts contexts) => _abilities = contexts.chips.GetGroup(State);

		private static GameStateMachine GameStateMachine => ServicesMediator.GameStateMachine;

		public void Cleanup()
		{
			if (GameStateMachine.CurrentState is WaitingGameState
			    && _abilities.All((e) => e.state.Value is not AbilityState.Casting))
				GameStateMachine.ToState<TurnEndedGameState>();
		}
	}
}