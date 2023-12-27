using Code.Component;
using Entitas;
using Entitas.Generic;
using static Code.Coordinates.Layer;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class MarkUnavailableByObstaclesSystem : IInitializeSystem
	{
		private readonly AvailabilityService _availability;
		private readonly IGroup<Entity<ChipsScope>> _abilities;
		private readonly IGroup<Entity<GameScope>> _targets;

		public MarkUnavailableByObstaclesSystem(Contexts contexts, AvailabilityService availability)
		{
			_availability = availability;

			_targets = contexts.GetGroup(GameMatcher.AllOf(AvailableToPick, Target));
			_abilities = contexts.GetGroup(AllOf(Get<Component.AbilityState>(), Get<ConsiderObstacles>()));
		}

		private static IMatcher<Entity<GameScope>> AvailableToPick => GameMatcher.Get<AvailableToPick>();

		private static IMatcher<Entity<GameScope>> Target => GameMatcher.Get<Target>();

		public void Initialize()
		{
			foreach (var ability in _abilities.WhereStateIs(AbilityState.Prepared))
			foreach (var target in _targets.GetEntities())
				_availability.AvailableByObstacles(target, ability);
		}
	}
}