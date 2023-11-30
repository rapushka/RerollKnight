using Code.Component;
using Entitas.Generic;

namespace Code
{
	public sealed class CastSwitchPositionsSystem : CastAbilitySystemBase<SwitchPositions>
	{
		public CastSwitchPositionsSystem(Contexts contexts, Query query) : base(contexts, query) { }

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			CurrentActor.Swap<Component.Coordinates, Coordinates>(with: target);
		}
	}
}