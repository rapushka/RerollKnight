using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class MarkUnavailableByRangeSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<GameScope>> _targets;
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		[Inject]
		public MarkUnavailableByRangeSystem(Contexts contexts)
		{
			_contexts = contexts;
			_targets = contexts.GetGroup(ScopeMatcher<GameScope>.Get<AvailableToPick>());
			_abilities = contexts.GetGroup(AllOf(Get<Component.AbilityState>(), Get<Range>()));
		}

		private Entity<GameScope> CurrentPlayer => _contexts.Get<GameScope>().Unique.GetEntity<CurrentPlayer>();

		public void Initialize()
		{
			foreach (var ability in _abilities.WhereStateIs(AbilityState.Prepared))
			foreach (var target in _targets.GetEntities())
			{
				var playerPosition = CurrentPlayer.GetCoordinates();
				var targetPosition = target.GetCoordinates();

				if (playerPosition.DistanceTo(targetPosition) > ability.Get<Range>().Value)
					target.Is<AvailableToPick>(false);
			}
		}
	}
}