using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Code.Coordinates.Layer;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class AvailabilityService
	{
		private readonly Contexts _contexts;
		private readonly MeasuringService _measuring;
		private readonly Pathfinding _pathfinding;
		private readonly VisionService _visionService;

		private readonly IGroup<Entity<GameScope>> _targets;

		[Inject]
		public AvailabilityService
		(
			Contexts contexts,
			MeasuringService measuring,
			Pathfinding pathfinding,
			VisionService visionService
		)
		{
			_contexts = contexts;
			_measuring = measuring;
			_pathfinding = pathfinding;
			_visionService = visionService;

			_targets = _contexts.GetGroup(Get<Target>());
		}

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void EnsureAvailableByAll(Entity<GameScope> target, Entity<ChipsScope> ability)
		{
			target.Is<AvailableToPick>(true);

			AvailableByRange(target, ability);
			AvailableByInactiveRange(target, ability);
			AvailableByTargetConstraints(target, ability);
			AvailableByObstacles(target, ability);
			AvailableByVisibility(target, ability);
		}

		public void MarkAllTargetsAvailable()
		{
			foreach (var e in _targets)
				e.Is<AvailableToPick>(true);
		}

		public void AvailableByRange(Entity<GameScope> target, Entity<ChipsScope> ability)
		{
			if (!ability.Has<Range>())
				return;

			var casterPosition = CurrentActor.GetCoordinates();
			var targetPosition = target.GetCoordinates();
			var distance = _measuring.Distance(casterPosition, targetPosition, ability.Has<AllowDiagonals>());

			if (distance > ability.Get<Range>().Value)
				target.Is<AvailableToPick>(false);
		}

		public void AvailableByInactiveRange(Entity<GameScope> target, Entity<ChipsScope> ability)
		{
			if (!ability.Has<InactiveRange>())
				return;

			var casterPosition = CurrentActor.GetCoordinates();
			var targetPosition = target.GetCoordinates();
			var distance = _measuring.Distance(casterPosition, targetPosition, ability.Has<AllowDiagonals>());

			if (distance <= ability.Get<InactiveRange>().Value)
				target.Is<AvailableToPick>(false);
		}

		public void AvailableByTargetConstraints(Entity<GameScope> target, Entity<ChipsScope> ability)
		{
			if (!ability.Has<TargetConstraints>())
				return;

			if (!ability.Get<TargetConstraints>().Value.All((cc) => cc.Match(target)))
				target.Is<AvailableToPick>(false);
		}

		public void AvailableByObstacles(Entity<GameScope> target, Entity<ChipsScope> ability)
		{
			if (!ability.Has<ConsiderObstacles>())
				return;

			var casterPosition = CurrentActor.GetCoordinates(withLayer: Default);
			var targetPosition = target.GetCoordinates(withLayer: Default);
			var allowDiagonals = ability.Has<AllowDiagonals>();

			var path = _pathfinding.FindPath(casterPosition, targetPosition, allowDiagonals);
			var pathLength = path.Count - 1;

			if (pathLength == -1 || pathLength > ability.Get<Range>().Value)
				target.Is<AvailableToPick>(false);
		}

		public void AvailableByVisibility(Entity<GameScope> target, Entity<ChipsScope> ability)
		{
			if (!ability.Has<ConstrainByVisibility>())
				return;

			var playerPosition = CurrentActor.GetCoordinates(withLayer: Default);
			var targetPosition = target.GetCoordinates(withLayer: Default);
			var isVisible = _visionService.IsVisible(playerPosition, targetPosition);

			if (!isVisible)
				target.Is<AvailableToPick>(false);
		}
	}
}