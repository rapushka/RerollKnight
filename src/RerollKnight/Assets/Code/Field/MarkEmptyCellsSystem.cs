using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class MarkEmptyCellsSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _cells;

		public MarkEmptyCellsSystem(Contexts contexts)
		{
			_cells = contexts.game.GetGroup(Cell);
		}

		public void Execute()
		{
			foreach (var cell in _cells)
			{
				cell.isEmpty = cell.IsEmpty();
			}
		}
	}
}