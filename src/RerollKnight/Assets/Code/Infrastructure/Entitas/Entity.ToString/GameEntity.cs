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
			yield return entity.ToString<DebugName, string>(defaultValue: "entity");

			if (entity.Has<Health>() && entity.Has<MaxHealth>())
				yield return $"health: ({entity.Get<Health>().Value}/{entity.Get<MaxHealth>().Value})";

			yield return entity.ToString<Label, string>(prefix: "\"", postfix: "\"");
			yield return entity.ToString<ViewOf, GameComponentID>(prefix: "view of: ");

			yield return entity.Is<PickedChip>() ? "<- picked" : string.Empty;

			yield return entity.ToString<Component.Coordinates, Coordinates>(prefix: "–");
			yield return entity.ToString<CoordinatesUnderField, Coordinates>(prefix: "_");

			yield return entity.Is<Target>() ? "\tt" : string.Empty;
			yield return entity.Is<AvailableToPick>() ? "a" : string.Empty;
			yield return entity.Is<PickedTarget>() ? "P" : string.Empty;
		}
	}
}