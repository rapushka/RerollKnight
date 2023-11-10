using System.Collections.Generic;
using Entitas.Generic;

namespace Code
{
	public class GameEntityFormatter : EntityComponentsListFormatter<GameScope>
	{
		protected override IEnumerable<string> CreateList(Entity<GameScope> entity)
		{
			yield return entity.creationIndex.ToString();
			yield return entity.ToString<DebugName, string>(defaultValue: "e");
			yield return entity.Is<PickedChip>() ? "<- picked" : string.Empty;

			yield return entity.ToString<CoordinatesComponent, Coordinates>(prefix: "–");
			yield return entity.ToString<CoordinatesUnderField, Coordinates>(prefix: "_");

			yield return entity.Is<Target>() ? "\tt" : string.Empty;
			yield return entity.Is<AvailableToPick>() ? "a" : string.Empty;
			yield return entity.Is<PickedTarget>() ? "P" : string.Empty;
		}
	}
}