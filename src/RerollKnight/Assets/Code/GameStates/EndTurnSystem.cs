using Entitas;

namespace Code
{
	public sealed class EndTurnSystem : ICleanupSystem
	{
		// ReSharper disable once UnusedParameter.Local - consistency
		public EndTurnSystem(Contexts contexts) { }

		private static GameStateMachine GameStateMachine => ServicesMediator.GameStateMachine;

		public void Cleanup()
		{
			if (GameStateMachine.CurrentState is WaitingGameState)
				GameStateMachine.ToState<TurnEndedGameState>();
		}
	}
}