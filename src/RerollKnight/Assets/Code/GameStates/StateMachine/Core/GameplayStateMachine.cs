using Entitas.Generic;
using Zenject;

namespace Code
{
	public class GameplayStateMachine : StateMachineBase
	{
		private readonly DiContainer _diContainer;

		[Inject]
		public GameplayStateMachine(DiContainer diContainer, Contexts contexts)
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
		}

		private void AddState<T>()
			where T : GameplayStateBase
		{
			AddState(_diContainer.Instantiate<T>());
		}
	}
}