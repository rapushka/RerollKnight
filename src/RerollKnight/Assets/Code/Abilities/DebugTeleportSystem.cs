using Entitas;
using static Code.GameState;
using static GameMatcher;

namespace Code
{
	public sealed class DebugTeleportSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _targets;
		private readonly Contexts _contexts;
		private readonly IGroup<GameEntity> _players;

		public DebugTeleportSystem(Contexts contexts)
		{
			_contexts = contexts;
			_targets = contexts.game.GetGroup(PickedTarget);
			_players = contexts.game.GetGroup(Player);
		}

		public void Execute()
		{
			if (_contexts.GameStateIs(WaitingForAbilityUsage))
			{
				TeleportPlayer();
				ResetGameState();
			}
		}

		private void TeleportPlayer()
		{
			foreach (var player in _players)
			foreach (var target in _targets)
			{
				player.ReplaceCoordinates(target.coordinatesUnderField.Value);
			}
		}

		private void ResetGameState() => _contexts.ToGameState(PickingChip);
	}
}