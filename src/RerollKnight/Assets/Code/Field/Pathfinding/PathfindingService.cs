using UnityEngine;

namespace Code
{
	public class PathfindingService
	{
		public int Distance(Coordinates first, Coordinates second, bool allowDiagonals = true)
			=> allowDiagonals
				? ChebyshevDistance(first, second)
				: ManhattanDistance(first, second);

		private static int ChebyshevDistance(Coordinates first, Coordinates second)
			=> Mathf.Max(first.Column.Delta(second.Column), first.Row.Delta(second.Row));

		private static int ManhattanDistance(Coordinates first, Coordinates second)
			=> Mathf.Abs(first.Column - second.Column) + Mathf.Abs(first.Row - second.Row);
	}
}