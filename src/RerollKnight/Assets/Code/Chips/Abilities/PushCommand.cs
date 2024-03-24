using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class PushCommand
	{
		public void Do(Entity<ChipsScope> ability, Entity<GameScope> target, int distance, Coordinates direction)
		{
			var hitObstacle = false;

			for (var i = 0; i < distance; i++)
			{
				var nextCoordinates = target.GetCoordinates() + direction;

				var index = Component.Coordinates.Index;
				if (index.HasEntity(nextCoordinates)
				    || !index.HasEntity(nextCoordinates.WithLayer(Coordinates.Layer.Bellow)))
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