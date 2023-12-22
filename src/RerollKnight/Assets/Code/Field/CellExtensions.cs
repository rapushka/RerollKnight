using Code.Component;
using Entitas.Generic;

namespace Code
{
	public static class CellExtensions
	{
		public static bool IsEmpty(this Entity<GameScope> @this) => !@this.IsOccupied();

		public static bool IsOccupied(this Entity<GameScope> @this)
			=> @this.GetCoordinates(withLayer: Coordinates.Layer.Default).IsOccupied();

		public static bool IsEmpty(this Coordinates @this) => !@this.IsOccupied();

		public static bool IsOccupied(this Coordinates @this)
		{
			var index = Component.Coordinates.Index;

			return index.HasEntity(@this)
			       && !index.GetEntity(@this).Is<Disabled>();
		}
	}
}