namespace Code
{
	public class GameStateMachine : StateMachineBase<IGameState>
	{
		protected override TypeDictionary<IGameState> States
			=> new()
			{
				new GameState1(this),
				new GameState2(),
			};
	}
}