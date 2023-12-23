using Code.Component;
using Entitas.Generic;
using UnityEngine;
using static Code.Coordinates.Layer;

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

			var counter = 100; // TODO: remove this sometimes:(

			var kickedWall = false;

			while (pushDelta != Coordinates.Zero.WithLayer(Ignore))
			{
				var nextCoordinates = target.GetCoordinates() + direction;

				var index = Component.Coordinates.Index;
				if (index.HasEntity(nextCoordinates)
				    || !index.HasEntity(nextCoordinates.WithLayer(Bellow)))
				{
					kickedWall = true;
					break;
				}

				target.ReplaceCoordinates(nextCoordinates);

				pushDelta -= direction;

				if (counter-- < 0)
				{
					Debug.LogError("prevent endless loop");
					break;
				}
			}

			if (kickedWall)
				target.TakeDamage(ability.GetOrDefault<CrashDamage>()?.Value ?? 0);
		}
	}
}