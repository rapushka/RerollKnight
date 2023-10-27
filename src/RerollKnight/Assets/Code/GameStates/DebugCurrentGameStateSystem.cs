using System;
using Entitas;

namespace Code
{
	public sealed class DebugCurrentGameStateSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Contexts _contexts;

		private GameEntity _stateEntity;

		public DebugCurrentGameStateSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		private static GameStateBase CurrentGameState => ServicesMediator.GameStateMachine.CurrentState;

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