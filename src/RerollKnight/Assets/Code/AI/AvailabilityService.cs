using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class AvailabilityService
	{
		private readonly Contexts _contexts;
		private readonly MeasuringService _measuring;
		private readonly Pathfinding _pathfinding;

		private readonly IGroup<Entity<GameScope>> _targets;

		[Inject]
		public AvailabilityService(Contexts contexts, MeasuringService measuring, Pathfinding pathfinding)
		{
			_contexts = contexts;
			_measuring = measuring;
			_pathfinding = pathfinding;

			_targets = _contexts.GetGroup(Get<Target>());
		}

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void EnsureAvailableByAll(Entity<GameScope> target, Entity<ChipsScope> ability)
		{
			// TODO: use these in systems
			target.Is<AvailableToPick>(true);

			AvailableByRange(target, ability);
			AvailableByInactiveRange(target, ability);
			AvailableByTargetConstraints(target, ability);
			AvailableByObstacles(target, ability);
		}

		public void MarkAllTargetsAvailable()
		{
			foreach (var e in _targets)
				e.Is<AvailableToPick>(true);
		}

		private void AvailableByRange(Entity<GameScope> target, Entity<ChipsScope> ability)
		{
			if (!ability.Has<Range>())
				return;

			var casterPosition = CurrentActor.GetCoordinates();
			var targetPosition = target.GetCoordinates();
			var distance = _measuring.Distance(casterPosition, targetPosition, ability.Has<AllowDiagonals>());

			if (distance > ability.Get<Range>().Value)
				target.Is<AvailableToPick>(false);
		}

		private void AvailableByInactiveRange(Entity<GameScope> target, Entity<ChipsScope> ability)
		{
			if (!ability.Has<InactiveRange>())
				return;

			var casterPosition = CurrentActor.GetCoordinates();
			var targetPosition = target.GetCoordinates();
			var distance = _measuring.Distance(casterPosition, targetPosition, ability.Has<AllowDiagonals>());

			if (distance <= ability.Get<InactiveRange>().Value)
				target.Is<AvailableToPick>(false);
		}

		private void AvailableByTargetConstraints(Entity<GameScope> target, Entity<ChipsScope> ability)
		{
			if (!ability.Has<TargetConstraints>())
				return;

			if (!ability.Get<TargetConstraints>().Value.All((cc) => cc.Match(target)))
				target.Is<AvailableToPick>(false);
		}

		private void AvailableByObstacles(Entity<GameScope> target, Entity<ChipsScope> ability)
		{
			if (!ability.Has<ConsiderObstacles>())
				return;

			var casterPosition = CurrentActor.GetCoordinates(withLayer: Coordinates.Layer.Default);
			var targetPosition = target.GetCoordinates(withLayer: Coordinates.Layer.Default);
			var allowDiagonals = ability.Has<AllowDiagonals>();
			var pathLength = _pathfinding.FindPath(casterPosition, targetPosition, allowDiagonals).Count - 1;

			if (pathLength == -1 || pathLength > ability.Get<Range>().Value)
				target.Is<AvailableToPick>(false);
		}
	}
}