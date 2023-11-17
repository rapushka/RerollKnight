using Entitas;

namespace Code
{
	public sealed class UpdateGameplayStateMachineSystem : IExecuteSystem
	{
		private readonly GameplayStateMachine _stateMachine;

		public UpdateGameplayStateMachineSystem(GameplayStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public void Execute()
		{
			_stateMachine.OnUpdate();
		}
	}
}