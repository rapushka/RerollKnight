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
		Entity<GameScope> NextEmptyCell();
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

		public Entity<GameScope> NextEmptyCell()
		{
			var wasRefilled = false;

			if (!_cells.Any())
			{
				Refill();
				wasRefilled = true;
			}

			var next = _cells.Dequeue();

			while (!IsEmpty(next))
			{
				if (_cells.Any())
				{
					next = _cells.Dequeue();
					continue;
				}

				if (wasRefilled)
					throw new InvalidOperationException("There's no empty cells anymore");

				Refill();
				wasRefilled = true;
			}

			return next;
		}

		private static bool IsEmpty(Entity<GameScope> cell)
		{
			cell.Is<Empty>(cell.IsEmpty());
			return cell.Is<Empty>();
		}

		private void Refill()
		{
			_cells = _contexts.GetGroup(AllOf(Get<Cell>(), Get<Empty>())).GetEntities().Shuffle().ToList();
		}
	}
}