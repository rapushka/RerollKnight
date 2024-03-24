using Code.Component;
using Entitas.Generic;
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

			var hitObstacle = false;

			for (var i = 0; i < distance; i++)
			{
				var nextCoordinates = target.GetCoordinates() + direction;

				var index = Component.Coordinates.Index;
				if (index.HasEntity(nextCoordinates)
				    || !index.HasEntity(nextCoordinates.WithLayer(Bellow)))
				{
					hitObstacle = true;
					break;
				}

				target.ReplaceCoordinates(nextCoordinates);
			}

			if (hitObstacle)
				target.TakeDamage(ability.GetOrDefault<CrashDamage>()?.Value ?? 0);
		}
	}
}