using System;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class GameStateMachine : StateMachineBase<GameStateBase>, ITickable, IDisposable
	{
		private readonly StateChangeBus _stateChangeBus;

		[Inject]
		public GameStateMachine(DiContainer diContainer, Contexts contexts, StateChangeBus stateChangeBus)
		{
			AddState(diContainer.Instantiate<ObservingGameState>());
			AddState(diContainer.Instantiate<ChipPickedGameState>());
			AddState(diContainer.Instantiate<WaitingGameState>());
			AddState(diContainer.Instantiate<TurnEndedGameState>());

			// ToState<ObservingGameState>();

			_stateChangeBus = stateChangeBus;
			_stateChangeBus.StateChangeRequired += ToState;
		}

		void ITickable.Tick() => OnUpdate();

		public void Dispose() => _stateChangeBus.StateChangeRequired -= ToState;
	}
}