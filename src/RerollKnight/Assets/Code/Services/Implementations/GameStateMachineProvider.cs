namespace Code
{
	public interface IGameStateMachineProvider
	{
		GameStateMachine StateMachine { get; }
	}

	public class GameStateMachineProvider
		: IGameStateMachineProvider
	{
		public GameStateMachine StateMachine { get; } = new();
	}
}