using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class CastSwitchPositionsSystem : CastAbilitySystemBase<SwitchPositions>
	{
		public CastSwitchPositionsSystem(Contexts contexts) : base(contexts) { }

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			Debug.Assert(target.Has<Component.Coordinates>());

			CurrentActor.Swap<Component.Coordinates, Coordinates>(with: target);
		}
	}
}