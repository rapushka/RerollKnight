using Entitas;

namespace Code
{
	public sealed class StartGameSystem : IInitializeSystem
	{
		private readonly GameStateMachine _gameStateMachine;

		public StartGameSystem(GameStateMachine gameStateMachine)
			=> _gameStateMachine = gameStateMachine;

		public void Initialize() => _gameStateMachine.ToState<ObservingGameState>();
	}
}