using Entitas;
using UnityEngine;
using static ChipsMatcher;

namespace Code
{
	public sealed class CastTeleportSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _players;
		private readonly IGroup<GameEntity> _targets;
		private readonly IGroup<ChipsEntity> _abilities;

		public CastTeleportSystem(Contexts contexts)
		{
			_players = contexts.game.GetGroup(GameMatcher.Player);
			_targets = contexts.game.GetGroup(GameMatcher.PickedTarget);
			_abilities = contexts.chips.GetGroup(AllOf(Teleport, Cast));
		}

		public void Execute()
		{
			foreach (var e in _abilities)
			foreach (var player in _players)
			foreach (var target in _targets)
			{
				Debug.Log("cast teleport");
				player.ReplaceCoordinates(target.coordinatesUnderField.Value);
			}
		}
	}
}