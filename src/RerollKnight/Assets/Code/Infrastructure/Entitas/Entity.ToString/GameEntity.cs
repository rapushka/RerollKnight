using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class GameEntityFormatter : EntityComponentsListFormatter<GameScope>
	{
		protected override IEnumerable<string> CreateList(Entity<GameScope> entity)
		{
			yield return entity.creationIndex.ToString();
			yield return entity.ToString<DebugName, string>(defaultValue: "e");

			if (entity.Has<Health>() && entity.Has<MaxHealth>())
				yield return $"health: ({entity.Get<Health>().Value}/{entity.Get<MaxHealth>().Value})";

			yield return entity.ToString<Label, string>(prefix: "\"", postfix: "\"");

			yield return entity.ToString<Component.Coordinates, Coordinates>();

			yield return entity.Is<Target>() ? "\ttarget" : string.Empty;
			yield return entity.Is<AvailableToPick>() ? "available" : string.Empty;
			yield return entity.Is<PickedTarget>() ? "PICKED" : string.Empty;

			yield return entity.Is<PickedChip>() ? "<- picked" : string.Empty;

			yield return entity.ToString<Face, int>(prefix: "face: ");
		}
	}
}