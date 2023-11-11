using Entitas;

namespace Code
{
	public sealed class ToGameStateSystem<TState> : IInitializeSystem 
		where TState : GameStateBase
	{
		private readonly GameStateMachine _stateMachine;

		public ToGameStateSystem(GameStateMachine stateMachine) => _stateMachine = stateMachine;

		public void Initialize() => _stateMachine.ToState<TState>();
	}
}