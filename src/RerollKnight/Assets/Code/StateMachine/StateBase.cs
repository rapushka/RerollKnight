namespace Code
{
	public abstract class StateBase : IState
	{
		public abstract void Enter(StateMachineBase stateMachine);
	}
}