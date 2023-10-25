namespace Code
{
	public class GameStateMachine : StateMachineBase
	{
		protected override TypeDictionary<IState> States
			=> new()
			{
				new SomeGameState(this),
				new AnotherGameState(this),
			};
	}
}