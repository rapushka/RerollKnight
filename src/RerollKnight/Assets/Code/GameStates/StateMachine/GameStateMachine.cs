namespace Code
{
	public class GameStateMachine : StateMachineBase<GameStateBase>
	{
		protected override TypeDictionary<GameStateBase> States
			=> new()
			{
			};
	}
}