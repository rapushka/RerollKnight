namespace Code
{
	public abstract class GameStateBase : StateBase<GameStateMachine>
	{
		protected GameStateBase(GameStateMachine stateMachine) : base(stateMachine) { }
	}
}