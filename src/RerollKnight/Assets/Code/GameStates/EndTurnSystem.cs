using Entitas;
using static ChipsMatcher;

namespace Code
{
	public sealed class EndTurnSystem : ICleanupSystem
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly IGroup<ChipsEntity> _abilities;

		public EndTurnSystem(Contexts contexts, GameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;
			_abilities = contexts.chips.GetGroup(State);
		}

		public void Cleanup()
		{
			if (_gameStateMachine.CurrentState is WaitingGameState
			    && _abilities.All((e) => e.state.Value is not AbilityState.Casting))
				_gameStateMachine.ToState<TurnEndedGameState>();
		}
	}
}