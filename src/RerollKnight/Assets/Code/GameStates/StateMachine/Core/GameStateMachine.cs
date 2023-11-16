using System;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class GameStateMachine : StateMachineBase<GameStateBase>, IDisposable
	{
		private readonly StateChangeBus _stateChangeBus;

		[Inject]
		public GameStateMachine(DiContainer diContainer, Contexts contexts, StateChangeBus stateChangeBus)
		{
			AddState(diContainer.Instantiate<ObservingGameState>());
			AddState(diContainer.Instantiate<ChipPickedGameState>());
			AddState(diContainer.Instantiate<WaitingGameState>());
			AddState(diContainer.Instantiate<TurnEndedGameState>());
			AddState(diContainer.Instantiate<OtherPlayerTurnGameState>());

			// ToState<ObservingGameState>();

			_stateChangeBus = stateChangeBus;
			_stateChangeBus.StateChangeRequired += ToState;
		}

		public void Dispose() => _stateChangeBus.StateChangeRequired -= ToState;
	}
}