using Entitas;

namespace Code
{
	public sealed class UpdateGameplayStateMachineSystem : IExecuteSystem, ICleanupSystem
	{
		private readonly GameplayStateMachine _stateMachine;

		public UpdateGameplayStateMachineSystem(GameplayStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public void Execute() => _stateMachine.Execute();

		public void Cleanup() => _stateMachine.Cleanup();
	}
}