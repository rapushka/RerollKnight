using Code.Component;
using Entitas;
using Entitas.Generic;
using static Code.Coordinates.Layer;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class MarkUnavailableByVisibilitySystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly VisionService _visionService;
		private readonly IGroup<Entity<ChipsScope>> _abilities;
		private readonly IGroup<Entity<GameScope>> _targets;

		public MarkUnavailableByVisibilitySystem(Contexts contexts, VisionService visionService)
		{
			_contexts = contexts;
			_visionService = visionService;

			_targets = contexts.GetGroup(GameMatcher.AllOf(AvailableToPick, Target));
			_abilities = contexts.GetGroup(AllOf(Get<Component.AbilityState>(), Get<ConstrainByVisibility>()));
		}

		private static IMatcher<Entity<GameScope>> AvailableToPick => GameMatcher.Get<AvailableToPick>();

		private static IMatcher<Entity<GameScope>> Target => GameMatcher.Get<Target>();

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			foreach (var _ in _abilities.WhereStateIs(AbilityState.Prepared))
			foreach (var target in _targets.GetEntities())
			{
				var playerPosition = CurrentActor.GetCoordinates(withLayer: Default);
				var targetPosition = target.GetCoordinates(withLayer: Default);
				var isVisible = _visionService.IsVisible(playerPosition, targetPosition);

				if (!isVisible)
					target.Is<AvailableToPick>(false);
			}
		}
	}
}