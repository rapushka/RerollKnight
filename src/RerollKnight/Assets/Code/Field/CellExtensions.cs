using Entitas.Generic;

namespace Code
{
	public static class CellExtensions
	{
		public static bool IsOccupied(this Entity<GameScope> @this)
			=> Component.Coordinates.Index.HasEntity(@this.GetCoordinates());
		// return _context.HasEntityWithCoordinates(cellCoordinates);

		public static bool IsEmpty(this Entity<GameScope> @this) => !@this.IsOccupied();
	}
}