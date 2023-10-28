using Zenject;

namespace Code
{
	public class GameStateMachine : StateMachineBase<GameStateBase>
	{
		[Inject]
		public GameStateMachine(IEntitiesManipulatorService entitiesManipulator)
		{
			AddState(new ObservingGameState(this, entitiesManipulator));
			AddState(new WaitingGameState(this));
			AddState(new ChipPickedGameState(this));
			AddState(new TurnEndedGameState(this));

			// ToState<ObservingGameState>();
		}
	}
}