using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class DebugCurrentGameplayStateSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly GameplayStateMachine _gameplayStateMachine;

		private Entity<GameScope> _stateEntity;

		public DebugCurrentGameplayStateSystem(Contexts contexts, GameplayStateMachine gameplayStateMachine)
		{
			_contexts = contexts;
			_gameplayStateMachine = gameplayStateMachine;
		}

		private GameplayStateBase CurrentGameplayState => _gameplayStateMachine.CurrentState;

		public void Initialize()
		{
			_stateEntity = _contexts.Get<GameScope>().CreateEntity();
		}

		public void Execute()
		{
			_stateEntity.Replace<DebugName, string>($"Game State: {CurrentGameplayState.GetType().Name}");
		}
	}
}