using Entitas.Generic;

namespace Code
{
	public static class CellExtensions
	{
		public static bool IsOccupied(this Entity<GameScope> @this)
			=> Component.Coordinates.Index.HasEntity(@this.GetCoordinates());

		public static bool IsEmpty(this Entity<GameScope> @this) => !@this.IsOccupied();
	}
}