using Code.Component;
using Entitas.Generic;
using static Code.Coordinates.Layer;

namespace Code
{
	public sealed class CastSwapPositionsSystem : CastAbilitySystemBase<SwapPositions>
	{
		public CastSwapPositionsSystem(Contexts contexts) : base(contexts) { }

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			var targetCoordinates = target.GetCoordinates().WithLayer(Default);

			if (Component.Coordinates.Index.HasEntity(targetCoordinates))
				CurrentActor.Swap<Component.Coordinates, Coordinates>(with: target);
			else
				CurrentActor.ReplaceCoordinates(targetCoordinates);
		}
	}
}