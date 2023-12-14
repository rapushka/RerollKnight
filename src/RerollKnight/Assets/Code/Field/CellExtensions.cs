using Code.Component;
using Entitas.Generic;

namespace Code
{
	public static class CellExtensions
	{
		public static bool IsOccupied(this Entity<GameScope> @this)
		{
			var index = Component.Coordinates.Index;
			var onCellCoordinates = @this.GetCoordinates(withLayer: Coordinates.Layer.Default);

			return index.HasEntity(onCellCoordinates)
				&& !index.GetEntity(onCellCoordinates).Is<Disabled>();
		}

		public static bool IsEmpty(this Entity<GameScope> @this) => !@this.IsOccupied();
	}
}