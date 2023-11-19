using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class CastSwitchPositionsSystem : CastAbilitySystemBase
	{
		public CastSwitchPositionsSystem(Contexts contexts) : base(contexts) { }

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			Debug.Assert(target.Has<Component.Coordinates>());

			var targetCoordinates = target.Get<Component.Coordinates>().Value;
			var casterCoordinates = CurrentActor.Get<Component.Coordinates>().Value;

			CurrentActor.Replace<Component.Coordinates, Coordinates>(targetCoordinates);
			target.Replace<Component.Coordinates, Coordinates>(casterCoordinates);
		}
	}
}