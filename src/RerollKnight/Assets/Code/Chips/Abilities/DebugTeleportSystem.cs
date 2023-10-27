using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class DebugTeleportSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _targets;
		private readonly IGroup<GameEntity> _players;

		public DebugTeleportSystem(Contexts contexts)
		{
			_targets = contexts.game.GetGroup(PickedTarget);
			_players = contexts.game.GetGroup(Player);
		}

		public void Execute()
		{
			if (ServicesMediator.GameStateMachine.CurrentState is WaitingGameState)
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

		private void ResetGameState() => ServicesMediator.GameStateMachine.ToState<ObservingGameState>();
	}
}