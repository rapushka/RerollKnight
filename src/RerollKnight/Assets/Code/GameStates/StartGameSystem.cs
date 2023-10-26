using Entitas;

namespace Code
{
	public sealed class StartGameSystem : IInitializeSystem
	{
		// ReSharper disable once UnusedParameter.Local - consistency
		public StartGameSystem(Contexts contexts) { }

		public void Initialize() => ServicesMediator.GameStateMachine.ToState<ObservingGameState>();
	}
}