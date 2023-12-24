using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class CastRecoilSystem : CastAbilitySystemBase<Recoil>
	{
		public CastRecoilSystem(Contexts contexts) : base(contexts) { }

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			var targetCoordinates = target.GetCoordinates();
			var casterCoordinates = CurrentActor.GetCoordinates();

			var direction = (casterCoordinates - targetCoordinates).Normalize();
			var distance = ability.Get<Recoil>().Value;
			var pushDelta = direction * distance;

			var counter = 100; // TODO: remove this sometimes:(

			var kickedWall = false;

			while (pushDelta != Coordinates.Zero.WithLayer(Coordinates.Layer.Ignore))
			{
				var nextCoordinates = CurrentActor.GetCoordinates() + direction;

				var index = Component.Coordinates.Index;
				if (index.HasEntity(nextCoordinates)
				    || !index.HasEntity(nextCoordinates.WithLayer(Coordinates.Layer.Bellow)))
				{
					kickedWall = true;
					break;
				}

				CurrentActor.ReplaceCoordinates(nextCoordinates);

				pushDelta -= direction;

				if (counter-- < 0)
				{
					Debug.LogError("prevent endless loop");
					break;
				}
			}

			if (kickedWall)
				CurrentActor.TakeDamage(ability.GetOrDefault<CrashDamage>()?.Value ?? 0);
		}
	}
}