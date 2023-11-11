using Entitas.Generic;
using Zenject;

namespace Code
{
	public class GameStateMachine : StateMachineBase<GameStateBase>, ITickable
	{
		[Inject]
		public GameStateMachine(DiContainer diContainer, Contexts contexts)
		{
			AddState(diContainer.Instantiate<ObservingGameState>());
			AddState(diContainer.Instantiate<ChipPickedGameState>());
			AddState(diContainer.Instantiate<WaitingGameState>());
			AddState(diContainer.Instantiate<TurnEndedGameState>());

			// ToState<ObservingGameState>();
		}

		void ITickable.Tick() => OnUpdate();
	}
}