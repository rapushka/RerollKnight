using Entitas;

namespace Code
{
	public sealed class DebugCurrentGameStateSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly GameStateMachine _gameStateMachine;

		private GameEntity _stateEntity;

		public DebugCurrentGameStateSystem(Contexts contexts, GameStateMachine gameStateMachine)
		{
			_contexts = contexts;
			_gameStateMachine = gameStateMachine;
		}

		private GameStateBase CurrentGameState => _gameStateMachine.CurrentState;

		public void Initialize()
		{
			_stateEntity = _contexts.game.CreateEntity();
		}

		public void Execute()
		{
			_stateEntity.ReplaceDebugName($"Game State: {CurrentGameState.GetType().Name}");
		}
	}
}