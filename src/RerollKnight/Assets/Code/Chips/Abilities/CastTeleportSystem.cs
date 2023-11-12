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
		private readonly IGroup<Entity<GameScope>> _players;
		private readonly IGroup<Entity<GameScope>> _targets;
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		[Inject]
		public CastTeleportSystem(Contexts contexts)
		{
			_players = contexts.GetGroup(GameMatcher.Get<Player>());
			_targets = contexts.GetGroup(GameMatcher.Get<PickedTarget>());
			_abilities = contexts.GetGroup(AllOf(Get<Teleport>(), Get<Component.AbilityState>()));
		}

		public void Initialize()
		{
			foreach (var ability in _abilities.WhereStateIs(AbilityState.Casting))
			foreach (var player in _players)
			foreach (var target in _targets)
			{
				player.Replace<Component.Coordinates, Coordinates>(target.GetCoordinates());
				ability.Replace<Component.AbilityState, AbilityState>(AbilityState.Casted);
			}
		}
	}
}