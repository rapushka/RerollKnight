namespace Code
{
	public abstract class StateBase<TStateMachine> : IState
		where TStateMachine : StateMachineBase
	{
		protected readonly TStateMachine StateMachine;

		protected StateBase(TStateMachine stateMachine)
		{
			StateMachine = stateMachine;
		}

		public abstract void Enter();
	}
}