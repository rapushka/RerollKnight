using System.Linq;
using Entitas;
using static ChipsMatcher;
using static GameMatcher;

namespace Code
{
	public sealed class ConstraintAbilityRangeSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _targets;
		private readonly IGroup<ChipsEntity> _abilities;
		private readonly IGroup<GameEntity> _players;

		public ConstraintAbilityRangeSystem(Contexts contexts)
		{
			_targets = contexts.game.GetGroup(PickedTarget);
			_players = contexts.game.GetGroup(Player);
			_abilities = contexts.chips.GetGroup(AllOf(State, Range));
		}

		private bool HasConstraints => _abilities.GetEntities().Any();

		public void Execute()
		{
			if (!HasConstraints)
				return;

			foreach (var ability in _abilities.WhereStateIs(AbilityState.Prepared))
			foreach (var player in _players)
			foreach (var target in _targets.GetEntities())
			{
				var playerPosition = player.GetCoordinates();
				var targetPosition = target.GetCoordinates();

				if (playerPosition.DistanceTo(targetPosition) > ability.range.Value)
				{
					target.Unpick();
					break;
				}
			}
		}
	}
}