namespace Code
{
	public class GameStateMachine : StateMachineBase<GameStateBase>
	{
		protected override TypeDictionary<GameStateBase> States
			=> new()
			{
				new ObservingGameState(this),
				new WaitingGameState(this),
				new ChipPickedGameState(this),
				new TurnEndedGameState(this),
			};
	}
}