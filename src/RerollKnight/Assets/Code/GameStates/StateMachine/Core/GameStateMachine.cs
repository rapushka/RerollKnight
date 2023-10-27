namespace Code
{
	public class GameStateMachine : StateMachineBase<GameStateBase>
	{
		public GameStateMachine()
		{
			AddState(new ObservingGameState(this));
			AddState(new WaitingGameState(this));
			AddState(new ChipPickedGameState(this));
			AddState(new TurnEndedGameState(this));

			// ToState<ObservingGameState>();
		}
	}
}