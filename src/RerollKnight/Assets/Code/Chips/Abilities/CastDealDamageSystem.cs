using System;
using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class CastDealDamageSystem : CastAbilitySystemBase<DealDamage>
	{
		public CastDealDamageSystem(Contexts contexts) : base(contexts) { }

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			if (ability.Has<PerpendicularSpread>())
			{
				ShootWithSpread(ability, target);
				return;
			}

			target.TakeDamage(ability.Get<DealDamage>().Value);
		}

		private void ShootWithSpread(Entity<ChipsScope> ability, Entity<GameScope> target) // TODO: doesn't wokr:(((
		{
			var targetCoordinates = target.GetCoordinates();
			var casterCoordinates = CurrentActor.GetCoordinates();

			var direction = (casterCoordinates - targetCoordinates).Normalize();
			var spreadSize = ability.Get<PerpendicularSpread>().Value;

			var spreadDirection
				= direction.Column != 0 ? new Coordinates(column: 0, row: 1)
				: direction.Row != 0    ? new Coordinates(column: 1, row: 0)
				                          : throw new InvalidOperationException();

			var spread = spreadDirection * spreadSize;

			var counter = 100; // TODO: remove:(

			while (spreadDirection != Coordinates.Zero.WithLayer(Coordinates.Layer.Ignore))
			{
				DoDamageIfHasEntity(ability, targetCoordinates - spread);
				DoDamageIfHasEntity(ability, targetCoordinates + spread);

				spread -= spreadDirection;

				if (counter-- < 0)
				{
					Debug.LogError("prevent endless loop");
					break;
				}
			}

			DoDamageIfHasEntity(ability, targetCoordinates);
		}

		private static void DoDamageIfHasEntity(Entity<ChipsScope> ability, Coordinates coordinates)
		{
			if (TryGetEntity(coordinates, out var target))
				target.TakeDamage(ability.Get<DealDamage>().Value);
		}

		private static bool TryGetEntity(Coordinates coordinates, out Entity<GameScope> entity)
		{
			entity = null;
			var defaultCoordinates = coordinates.WithLayer(Coordinates.Layer.Default);
			var index = Component.Coordinates.Index;
			var has = index.HasEntity(defaultCoordinates);

			if (has)
				entity = index.GetEntity(defaultCoordinates);

			return has;
		}
	}
}