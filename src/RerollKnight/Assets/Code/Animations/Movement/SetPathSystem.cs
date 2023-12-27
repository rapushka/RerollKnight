using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class SetPathSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly Pathfinding _pathfinding;
		private readonly IGroup<Entity<ChipsScope>> _abilities;
		private readonly IGroup<Entity<GameScope>> _targets;

		public SetPathSystem(Contexts contexts, Pathfinding pathfinding)
		{
			_contexts = contexts;
			_pathfinding = pathfinding;

			_targets = contexts.GetGroup(PickedTarget);
			_abilities = contexts.GetGroup(AllOf(Get<Component.AbilityState>(), Get<ConsiderObstacles>()));
		}

		private static IMatcher<Entity<GameScope>> PickedTarget => GameMatcher.Get<PickedTarget>();

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			foreach (var ability in _abilities.WhereStateIs(AbilityState.Prepared))
			foreach (var target in _targets.GetEntities())
			{
				if (!ability.Has<ConsiderObstacles>())
					continue;

				var casterPosition = CurrentActor.GetCoordinates(withLayer: Coordinates.Layer.Default);
				var targetPosition = target.GetCoordinates(withLayer: Coordinates.Layer.Default);
				var allowDiagonals = ability.Has<AllowDiagonals>();

				var path = _pathfinding.FindPath(casterPosition, targetPosition, allowDiagonals);

				var defaultsPath = path.Select((c) => c.WithLayer(Coordinates.Layer.Default)).ToList();
				CurrentActor.Replace<Path, List<Coordinates>>(defaultsPath);
			}
		}
	}
}