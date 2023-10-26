namespace Code
{
	public interface IGameStateMachineProvider
	{
		GameStateMachine StateMachine { get; }
	}

	public class GameStateMachineProvider
		: IGameStateMachineProvider
	{
		public GameStateMachineProvider(Contexts contexts)
			=> StateMachine = new GameStateMachine(contexts);

		public GameStateMachine StateMachine { get; }
	}
}