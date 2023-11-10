using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class DebugCurrentGameStateSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly GameStateMachine _gameStateMachine;

		private Entity<GameScope> _stateEntity;

		public DebugCurrentGameStateSystem(Contexts contexts, GameStateMachine gameStateMachine)
		{
			_contexts = contexts;
			_gameStateMachine = gameStateMachine;
		}

		private GameStateBase CurrentGameState => _gameStateMachine.CurrentState;

		public void Initialize()
		{
			_stateEntity = _contexts.Get<GameScope>().CreateEntity();
		}

		public void Execute()
		{
			_stateEntity.Replace<DebugName, string>($"Game State: {CurrentGameState.GetType().Name}");
		}
	}
}