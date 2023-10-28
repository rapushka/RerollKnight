using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class DebugTeleportSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _targets;
		private readonly IGroup<GameEntity> _players;
		private readonly GameStateMachine _gameStateMachine;

		public DebugTeleportSystem(Contexts contexts, GameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;

			_targets = contexts.game.GetGroup(PickedTarget);
			_players = contexts.game.GetGroup(Player);
		}

		public void Execute()
		{
			if (_gameStateMachine.CurrentState is WaitingGameState)
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

		private void ResetGameState() => _gameStateMachine.ToState<ObservingGameState>();
	}
}