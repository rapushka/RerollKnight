using System.Collections.Generic;
using System.Linq;

namespace Code
{
	public static class CoordinatesIterationExtensions
	{
		public static IEnumerable<Coordinates> Neighbors(this Coordinates @this, bool allowDiagonal = false)
			=> allowDiagonal ? @this.NeighborsWithDiagonals() : @this.NeighborsWithoutDiagonals();

		private static IEnumerable<Coordinates> NeighborsWithoutDiagonals(this Coordinates @this)
			=> @this.NeighborsWithDiagonals().Where((c) => @this.Column == c.Column || @this.Row == c.Row);

		private static IEnumerable<Coordinates> NeighborsWithDiagonals(this Coordinates @this)
		{
			var start = @this.Add(column: -1, row: -1);
			var end = @this.Add(column: 1, row: 1);

			var current = start;

			while (current.Column <= end.Column && current.Row <= end.Column)
			{
				if (current != @this)
					yield return current;

				current = current.NextCoordinates(end);
			}
		}

		private static Coordinates NextCoordinates(this Coordinates @this, Coordinates end)
			=> @this.Column < end.Column
				? @this.Add(column: 1)
				: @this.WithColumn(0).Add(row: 1);
	}
}