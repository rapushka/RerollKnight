using Entitas;

namespace Code
{
	public sealed class UpdateGameStateMachineSystem : IExecuteSystem
	{
		private readonly GameStateMachine _stateMachine;

		public UpdateGameStateMachineSystem(GameStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public void Execute()
		{
			_stateMachine.OnUpdate();
		}
	}
}