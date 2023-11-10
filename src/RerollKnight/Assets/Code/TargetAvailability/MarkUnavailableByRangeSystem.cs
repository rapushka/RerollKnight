using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class MarkUnavailableByRangeSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _targets;
		private readonly IGroup<Entity<GameScope>> _players;
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		[Inject]
		public MarkUnavailableByRangeSystem(Contexts contexts)
		{
			_targets = contexts.GetGroup(ScopeMatcher<GameScope>.Get<AvailableToPick>());
			_players = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Player>());
			_abilities = contexts.GetGroup(AllOf(Get<State>(), Get<Range>()));
		}

		public void Execute()
		{
			foreach (var ability in _abilities.WhereStateIs(AbilityState.Prepared))
			foreach (var player in _players)
			foreach (var target in _targets.GetEntities())
			{
				var playerPosition = player.GetCoordinates();
				var targetPosition = target.GetCoordinates();

				if (playerPosition.DistanceTo(targetPosition) > ability.Get<Range>().Value)
					target.Is<AvailableToPick>(false);
			}
		}
	}
}