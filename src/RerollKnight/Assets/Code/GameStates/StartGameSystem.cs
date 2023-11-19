using Entitas;

namespace Code
{
	public sealed class StartGameSystem : IInitializeSystem
	{
		private readonly GameplayStateMachine _gameplayStateMachine;

		public StartGameSystem(GameplayStateMachine gameplayStateMachine)
			=> _gameplayStateMachine = gameplayStateMachine;

		public void Initialize() => _gameplayStateMachine.ToState<LoadAssetsGameplayState>();
	}
}