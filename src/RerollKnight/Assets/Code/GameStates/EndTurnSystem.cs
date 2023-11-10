using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class EndTurnSystem : ICleanupSystem
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		public EndTurnSystem(Contexts contexts, GameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;
			_abilities = contexts.GetGroup(Get<State>());
		}

		public void Cleanup()
		{
			if (_gameStateMachine.CurrentState is WaitingGameState
			    && _abilities.All((e) => e.Get<State>().Value is not AbilityState.Casting))
				_gameStateMachine.ToState<TurnEndedGameState>();
		}
	}
}