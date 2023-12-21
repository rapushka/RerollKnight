using System.Linq;
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
		private readonly Contexts _contexts;
		private readonly Pathfinding _pathfinding;
		private readonly IGroup<Entity<ChipsScope>> _abilities;
		private readonly IGroup<Entity<GameScope>> _targets;

		public MarkUnavailableByObstaclesSystem(Contexts contexts, Pathfinding pathfinding)
		{
			_contexts = contexts;
			_pathfinding = pathfinding;

			_targets = contexts.GetGroup(GameMatcher.AllOf(AvailableToPick, Target));
			_abilities = contexts.GetGroup(AllOf(Get<Component.AbilityState>(), Get<ConsiderObstacles>()));
		}

		private static IMatcher<Entity<GameScope>> AvailableToPick => GameMatcher.Get<AvailableToPick>();

		private static IMatcher<Entity<GameScope>> Target => GameMatcher.Get<Target>();

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			foreach (var ability in _abilities.WhereStateIs(AbilityState.Prepared))
			foreach (var target in _targets.GetEntities())
			{
				var playerPosition = CurrentActor.GetCoordinates(withLayer: Default);
				var targetPosition = target.GetCoordinates(withLayer: Default);
				var pathLength = _pathfinding.FindPath(playerPosition, targetPosition).Count() - 1;

				if (pathLength == -1 || pathLength > ability.Get<Range>().Value)
					target.Is<AvailableToPick>(false);
			}
		}
	}
}