using Entitas;
using Zenject;
using static GameMatcher;
using static ChipsMatcher;

namespace Code
{
	public sealed class MarkUnavailableByRangeSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _targets;
		private readonly IGroup<ChipsEntity> _abilities;
		private readonly IGroup<GameEntity> _players;

		[Inject]
		public MarkUnavailableByRangeSystem(Contexts contexts)
		{
			_targets = contexts.game.GetGroup(AvailableToPick);
			_players = contexts.game.GetGroup(Player);
			_abilities = contexts.chips.GetGroup(AllOf(State, Range));
		}

		public void Execute()
		{
			foreach (var ability in _abilities.WhereStateIs(AbilityState.Prepared))
			foreach (var player in _players)
			foreach (var target in _targets.GetEntities())
			{
				var playerPosition = player.GetCoordinates();
				var targetPosition = target.GetCoordinates();

				if (playerPosition.DistanceTo(targetPosition) > ability.range.Value)
					target.isAvailableToPick = false;
			}
		}
	}
}