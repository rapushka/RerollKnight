using System;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class GameplayStateMachine : StateMachineBase<GameplayStateBase>, IDisposable
	{
		private readonly StateChangeBus _stateChangeBus;

		[Inject]
		public GameplayStateMachine(DiContainer diContainer, Contexts contexts, StateChangeBus stateChangeBus)
		{
			AddState(diContainer.Instantiate<LoadAssetsGameplayState>());
			AddState(diContainer.Instantiate<InitializeGameplayState>());
			AddState(diContainer.Instantiate<ObservingGameplayState>());
			AddState(diContainer.Instantiate<ChipPickedGameplayState>());
			AddState(diContainer.Instantiate<WaitingGameplayState>());
			AddState(diContainer.Instantiate<TurnEndedGameplayState>());
			AddState(diContainer.Instantiate<OtherPlayerTurnGameplayState>());

			// ToState<ObservingGameplayState>();

			_stateChangeBus = stateChangeBus;
			_stateChangeBus.StateChangeRequired += ToState;
		}

		public void Dispose() => _stateChangeBus.StateChangeRequired -= ToState;
	}
}