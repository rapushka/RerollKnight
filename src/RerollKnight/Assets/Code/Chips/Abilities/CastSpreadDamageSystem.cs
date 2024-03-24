using System;
using Code.Component;
using Entitas.Generic;

namespace Code
{
	public sealed class CastSpreadDamageSystem : CastAbilitySystemBase<PerpendicularSpread>
	{
		public CastSpreadDamageSystem(Contexts contexts) : base(contexts) { }

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			ShootWithSpread(ability, target);
		}

		private void ShootWithSpread(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			var targetCoordinates = target.GetCoordinates();
			var casterCoordinates = CurrentActor.GetCoordinates();

			var direction = (targetCoordinates - casterCoordinates).Normalize();
			var spreadSize = ability.Get<PerpendicularSpread>().Value;

			var spreadDirection
				= direction.Column != 0 ? new Coordinates(column: 0, row: 1)
				: direction.Row != 0    ? new Coordinates(column: 1, row: 0)
				                          : throw new InvalidOperationException();

			for (var i = 1; i <= spreadSize; i++)
			{
				var spread = spreadDirection * i;

				DoDamageIfHasEntity(ability, targetCoordinates - spread);
				DoDamageIfHasEntity(ability, targetCoordinates + spread);
			}
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