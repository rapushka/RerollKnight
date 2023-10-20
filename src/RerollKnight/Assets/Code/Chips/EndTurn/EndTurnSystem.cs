using Entitas;

namespace Code
{
	public sealed class EndTurnSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;

		public EndTurnSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Execute()
		{
			if (!_contexts.GameStateIs(GameState.WaitingForAbilityUsage))
				return;

			_contexts.ToGameState(GameState.TurnEnded);
			SendRequest.UnpickAll();
		}
	}
}