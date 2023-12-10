using System;
using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public interface IRandomFieldAccess
	{
		Entity<GameScope> NextEmptyCell(Coordinates.Layer layer = Coordinates.Layer.Bellow);
	}

	public class RandomFieldAccess : IRandomFieldAccess
	{
		private readonly Contexts _contexts;

		private List<Entity<GameScope>> _cells = new();

		[Inject]
		public RandomFieldAccess(Contexts contexts)
		{
			_contexts = contexts;
		}

		public Entity<GameScope> NextEmptyCell(Coordinates.Layer layer = Coordinates.Layer.Bellow)
		{
			var wasRefilled = false;

			if (!CellsOnLayer(layer).Any())
			{
				Refill();
				wasRefilled = true;
			}

			var next = _cells.Dequeue();

			while (!IsEmpty(next) || !OnSameLayer(next, layer))
			{
				if (_cells.Any())
				{
					next = _cells.Dequeue();
					continue;
				}

				if (wasRefilled)
					throw NoEmptyCellException(layer);

				Refill();
				wasRefilled = true;
			}

			return next;
		}

		private IEnumerable<Entity<GameScope>> CellsOnLayer(Coordinates.Layer layer)
			=> _cells.Where((e) => OnSameLayer(e, layer));

		private static bool OnSameLayer(Entity<GameScope> entity, Coordinates.Layer layer)
			=> entity.GetCoordinates().OnLayer == layer;

		private static bool IsEmpty(Entity<GameScope> cell)
		{
			cell.Is<Empty>(cell.IsEmpty());
			return cell.Is<Empty>();
		}

		private void Refill()
		{
			_cells = _contexts.GetGroup(AllOf(Get<Cell>(), Get<Empty>())).GetEntities().Shuffle().ToList();
		}

		private static InvalidOperationException NoEmptyCellException(Coordinates.Layer layer)
			=> new($"There's no empty cells on layer {layer.ToString()} anymore");
	}
}