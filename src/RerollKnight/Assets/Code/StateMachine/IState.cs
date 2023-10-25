namespace Code
{
	public interface IState
	{
		void Enter(StateMachineBase stateMachine);
	}

	public interface IExitableState : IState
	{
		void Exit();
	}
}