using Entitas;

namespace Code
{
	public sealed class ToState<TState> : IInitializeSystem, IStateTransferSystem
		where TState : GameplayStateBase
	{
		public StateMachineBase StateMachine { get; set; }

		public void Initialize() => StateMachine.ToState<TState>();
	}
}