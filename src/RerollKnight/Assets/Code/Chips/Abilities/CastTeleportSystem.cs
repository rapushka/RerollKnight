using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class CastTeleportSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<GameScope>> _targets;
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		[Inject]
		public CastTeleportSystem(Contexts contexts)
		{
			_contexts = contexts;
			_targets = contexts.GetGroup(GameMatcher.Get<PickedTarget>());
			_abilities = contexts.GetGroup(AllOf(Get<Teleport>(), Get<Component.AbilityState>()));
		}

		private Entity<GameScope> CurrentPlayer => _contexts.Get<GameScope>().Unique.GetEntity<CurrentPlayer>();

		public void Initialize()
		{
			foreach (var ability in _abilities.WhereStateIs(AbilityState.Casting))
			foreach (var target in _targets)
			{
				CurrentPlayer.Replace<Component.Coordinates, Coordinates>(target.GetCoordinates());
				ability.Replace<Component.AbilityState, AbilityState>(AbilityState.Casted);
			}
		}
	}
}