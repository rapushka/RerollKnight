using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class CastPushSystem : CastAbilitySystemBase<PushDistance>
	{
		public CastPushSystem(Contexts contexts) : base(contexts) { }

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			var targetCoordinates = target.GetCoordinates();
			var casterCoordinates = CurrentActor.GetCoordinates();

			var direction = (targetCoordinates - casterCoordinates).Normalize();
			var distance = ability.Get<PushDistance>().Value;
			var pushDelta = direction * distance;

			while (pushDelta != Coordinates.Zero)
			{
				var nextCoordinates = target.GetCoordinates() + direction;

				if (Component.Coordinates.Index.HasEntity(nextCoordinates))
				{
					Debug.Log("Bonk");
					break;
				}

				target.ReplaceCoordinates(nextCoordinates);

				pushDelta -= direction;
			}
		}
	}
}