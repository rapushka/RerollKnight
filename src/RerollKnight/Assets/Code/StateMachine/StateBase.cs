namespace Code
{
	// ReSharper disable once UnusedTypeParameter - used to mark state
	public abstract class StateBase<TStateMachine> : IState
	{
		public abstract void Enter();
	}
}