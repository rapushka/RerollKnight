using System.Collections.Generic;
using System.Linq;

namespace Code
{
	public static class CoordinatesIterationExtensions
	{
		private static Coordinates _start;
		private static Coordinates _end;

		public static IEnumerable<Coordinates> Neighbors(this Coordinates @this, bool allowDiagonal = false)
			=> allowDiagonal ? @this.NeighborsWithDiagonals() : @this.NeighborsWithoutDiagonals();

		private static IEnumerable<Coordinates> NeighborsWithoutDiagonals(this Coordinates @this)
			=> @this.NeighborsWithDiagonals().Where((c) => @this.Column == c.Column || @this.Row == c.Row);

		private static IEnumerable<Coordinates> NeighborsWithDiagonals(this Coordinates @this)
		{
			_start = @this.Add(column: -1, row: -1);
			_end = @this.Add(column: 1, row: 1);

			var current = _start;

			while (current.Column <= _end.Column && current.Row <= _end.Row)
			{
				if (current != @this)
					yield return current;

				current = current.NextCoordinates();
			}
		}

		private static Coordinates NextCoordinates(this Coordinates @this)
			=> @this.Column < _end.Column
				? @this.Add(column: 1)
				: @this.WithColumn(_start.Column).Add(row: 1);
	}
}