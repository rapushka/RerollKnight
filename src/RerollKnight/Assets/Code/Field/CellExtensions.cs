using Entitas.Generic;

namespace Code
{
	public static class CellExtensions
	{
		public static bool IsOccupied(this Entity<GameScope> @this)
			=> Component.Coordinates.Index.HasEntity(@this.GetCoordinates(withLayer: Coordinates.Layer.Default));

		public static bool IsEmpty(this Entity<GameScope> @this) => !@this.IsOccupied();
	}
}