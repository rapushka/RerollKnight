using Entitas;

namespace Code
{
	public sealed class StartGameSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public StartGameSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize() => _contexts.game.ReplaceGameState(GameState.PickingChip);
	}
}