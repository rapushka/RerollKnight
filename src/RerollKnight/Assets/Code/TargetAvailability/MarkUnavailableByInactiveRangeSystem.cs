using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class MarkUnavailableByInactiveRangeSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly MeasuringService _measuring;
		private readonly IGroup<Entity<GameScope>> _targets;
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		[Inject]
		public MarkUnavailableByInactiveRangeSystem(Contexts contexts, Query query, MeasuringService measuring)
		{
			_contexts = contexts;
			_measuring = measuring;

			_targets = contexts.GetGroup(GameMatcher.AllOf(AvailableToPick, Target));
			_abilities = contexts.GetGroup(AllOf(Get<Component.AbilityState>(), Get<InactiveRange>()));
		}

		private static IMatcher<Entity<GameScope>> AvailableToPick => GameMatcher.Get<AvailableToPick>();

		private static IMatcher<Entity<GameScope>> Target => GameMatcher.Get<Target>();

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			foreach (var ability in _abilities.WhereStateIs(AbilityState.Prepared))
			foreach (var target in _targets.GetEntities())
			{
				var playerPosition = CurrentActor.GetCoordinates();
				var targetPosition = target.GetCoordinates();
				var distance = _measuring.Distance(playerPosition, targetPosition, ability.Has<AllowDiagonals>());

				if (distance <= ability.Get<InactiveRange>().Value)
					target.Is<AvailableToPick>(false);
			}
		}
	}
}