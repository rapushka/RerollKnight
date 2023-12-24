using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
	public class VisionService
	{
		public bool IsVisible(Coordinates subject, Coordinates target)
		{
			var line = DrawLine(subject, target);

			var hasObstacleBetween = line.Skip(1).SkipLast(1).Any((c) => c.IsOccupied());
			return !hasObstacleBetween;
		}

		private IEnumerable<Coordinates> DrawLine(Coordinates start, Coordinates end)
		{
			var line = new List<Coordinates>();

			var x1 = start.Column;
			var y1 = start.Row;
			var x2 = end.Column;
			var y2 = end.Row;

			var steep = Mathf.Abs(y2 - y1) > Mathf.Abs(x2 - x1);
			if (steep)
			{
				// Swap x1 and y1
				var temp = x1;
				x1 = y1;
				y1 = temp;

				// Swap x2 and y2
				temp = x2;
				x2 = y2;
				y2 = temp;
			}

			var swapped = false;
			if (x1 > x2)
			{
				// Swap x1 and x2
				var temp = x1;
				x1 = x2;
				x2 = temp;

				// Swap y1 and y2
				temp = y1;
				y1 = y2;
				y2 = temp;

				swapped = true;
			}

			var dx = x2 - x1;
			var dy = Mathf.Abs(y2 - y1);
			var error = dx / 2;
			var yStep = y1 < y2 ? 1 : -1;
			var y = y1;

			for (var x = x1; x <= x2; x++)
			{
				line.Add(new Coordinates(steep ? y : x, steep ? x : y, Coordinates.Layer.Default));

				error -= dy;
				if (error < 0)
				{
					y += yStep;
					error += dx;
				}
			}

			if (swapped)
				line.Reverse();

			return line;
		}
	}
}