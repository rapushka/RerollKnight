using Entitas;
using static Code.GameState;

namespace Code
{
	public sealed class EndTurnSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;

		public EndTurnSystem(Contexts contexts) => _contexts = contexts;

		public void Execute() => _contexts.TransferGameState(from: WaitingForAbilityUsage, to: TurnEnded);
	}
}