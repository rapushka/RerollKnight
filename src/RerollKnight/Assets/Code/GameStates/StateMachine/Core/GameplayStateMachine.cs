using System;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class GameplayStateMachine : StateMachineBase<GameplayStateBase>, IDisposable
	{
		private readonly StateChangeBus _stateChangeBus;
		private readonly DiContainer _diContainer;

		[Inject]
		public GameplayStateMachine(DiContainer diContainer, Contexts contexts, StateChangeBus stateChangeBus)
		{
			_diContainer = diContainer;

			// Game preparations
			AddState<LoadLevelGameplayState>();
			AddState<InitializeGameplayState>();

			// Game loop
			AddState<ObservingGameplayState>();
			AddState<ChipPickedGameplayState>();
			AddState<CastingAbilitiesGameplayState>();
			AddState<TurnEndedGameplayState>();
			AddState<OtherPlayerTurnGameplayState>();

			// Tooling
			AddState<WaitAndThenToState<OtherPlayerTurnGameplayState>>();

			_stateChangeBus = stateChangeBus;
			_stateChangeBus.StateChangeRequired += ToState;
		}

		public void Dispose() => _stateChangeBus.StateChangeRequired -= ToState;

		private void AddState<T>()
			where T : GameplayStateBase
		{
			AddState(_diContainer.Instantiate<T>());
		}
	}
}