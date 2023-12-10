using Code.Component;
using Entitas.Generic;

namespace Code
{
	public sealed class CastTeleportSystem : CastAbilitySystemBase<Teleport>
	{
		public CastTeleportSystem(Contexts contexts, Query query) : base(contexts, query) { }

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			var coordinates = target.GetCoordinates(withLayer: Coordinates.Layer.Default);
			CurrentActor.Replace<Component.Coordinates, Coordinates>(coordinates);
		}
	}
}