using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class MarkEmptyCellsSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _cells;

		public MarkEmptyCellsSystem(Contexts contexts)
		{
			_cells = contexts.Get<GameScope>().GetGroup(ScopeMatcher<GameScope>.Get<Cell>());
		}

		public void Execute()
		{
			foreach (var cell in _cells)
				cell.Is<Empty>(cell.IsEmpty());
		}
	}
}