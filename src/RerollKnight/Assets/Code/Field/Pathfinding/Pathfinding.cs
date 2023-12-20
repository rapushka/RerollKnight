using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Code.Coordinates.Layer;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	/// <summary> A* </summary>
	public class Pathfinding
	{
		private const int DistanceBetweenCells = 1;

		private readonly MeasuringService _measuring;
		private readonly IGroup<Entity<GameScope>> _cells;

		private readonly List<PathNode> _grid = new();

		/// <summary> Coordinates we're now searching </summary>
		private readonly List<PathNode> _openList = new();

		/// <summary> Coordinates we've already searched </summary>
		private readonly List<PathNode> _closedList = new();

		[Inject]
		public Pathfinding(Contexts contexts, MapProvider map, MeasuringService measuring)
		{
			_measuring = measuring;

			_cells = contexts.GetGroup(Get<Cell>());
		}

		public IEnumerable<Coordinates> FindPath(Coordinates start, Coordinates end)
		{
			Cleanup();

			var startNode = new PathNode(start);
			var endNode = new PathNode(end);
			_openList.Add(startNode);

			_grid.AddRange(_cells.Select((c) => new PathNode(c.GetCoordinates(withLayer: Default))));

			startNode.GCost = 0;
			startNode.HCost = _measuring.Distance(startNode, endNode);

			// ---

			var counter = 10_000;

			while (_openList.Count > 0 && counter > 0)
			{
				var currentNode = _openList.GetMinFCostNode();

				if (currentNode == endNode)
					return CalculatePath(currentNode);

				_openList.Remove(currentNode);
				_closedList.Add(currentNode);

				foreach (var neighborNode in Neighbors(currentNode))
				{
					if (_closedList.Contains(neighborNode))
						continue;

					if (!neighborNode.IsEmpty)
					{
						_closedList.Add(neighborNode);
						continue;
					}

					var tentativeGCost = currentNode.GCost + DistanceBetweenCells;

					if (tentativeGCost < neighborNode.GCost)
					{
						neighborNode.PreviousNode = currentNode;
						neighborNode.GCost = tentativeGCost;
						neighborNode.HCost = _measuring.Distance(neighborNode, endNode);

						if (!_openList.Contains(neighborNode))
							_openList.Add(neighborNode);
					}
				}

				counter--;
			}

			if (counter <= 0)
				Debug.LogError("prevent endless loop");

			// ---

			return Enumerable.Empty<Coordinates>();
		}

		private IEnumerable<PathNode> Neighbors(PathNode currentNode)
			=> currentNode.Coordinates.Neighbors(allowDiagonal: true)
			              .Select((c) => new PathNode(c))
			              .Where((pn) => _grid.Contains(pn));

		private IEnumerable<Coordinates> CalculatePath(PathNode endNode)
		{
			var result = new List<Coordinates> { endNode };

			var currentNode = endNode;
			while (currentNode.PreviousNode is not null)
			{
				result.Add(currentNode.PreviousNode);
				currentNode = currentNode.PreviousNode;
			}

			result.Reverse();
			return result;
		}

		private void Cleanup()
		{
			_grid.Clear();
			_openList.Clear();
			_closedList.Clear();
		}
	}

	public static class PathfindingExtensions
	{
		public static PathNode GetMinFCostNode(this List<PathNode> list)
		{
			var minFCost = list.Min((pn) => pn.FCost);
			return list.First((pn) => pn.FCost == minFCost);
		}
	}
}