using Code.Component;
using Entitas.Generic;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class CastTeleportSystem : CastAbilitySystemBase<Teleport>
	{
		public CastTeleportSystem(Contexts contexts, Query query) : base(contexts, query) { }

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			CurrentActor.Replace<Component.Coordinates, Coordinates>(target.GetCoordinates());
		}
	}
}