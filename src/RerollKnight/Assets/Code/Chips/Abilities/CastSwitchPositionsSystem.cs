using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class CastSwitchPositionsSystem : CastAbilitySystemBase<SwitchPositions>
	{
		public CastSwitchPositionsSystem(Contexts contexts) : base(contexts) { }

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> targetCell)
		{
			var cellCoordinates = targetCell.GetCoordinates();
			var target = Component.Coordinates.Index.GetEntity(cellCoordinates);

			Debug.Assert(target.Has<Component.Coordinates>());

			var targetCoordinates = target.Get<Component.Coordinates>().Value;
			var casterCoordinates = CurrentActor.Get<Component.Coordinates>().Value;

			CurrentActor.Remove<Component.Coordinates>();
			target.Remove<Component.Coordinates>();

			CurrentActor.Replace<Component.Coordinates, Coordinates>(targetCoordinates);
			target.Replace<Component.Coordinates, Coordinates>(casterCoordinates);
		}
	}
}