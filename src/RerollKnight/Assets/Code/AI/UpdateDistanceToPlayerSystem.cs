using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Code.Coordinates.Layer;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class UpdateDistanceToPlayerSystem : IInitializeSystem
	{
		private readonly Pathfinding _pathfinding;
		private readonly IGroup<Entity<GameScope>> _players;
		private readonly IGroup<Entity<GameScope>> _emptyCells;

		[Inject]
		public UpdateDistanceToPlayerSystem(Contexts contexts, Pathfinding pathfinding)
		{
			_pathfinding = pathfinding;

			_players = contexts.GetGroup(Get<Player>());
			_emptyCells = contexts.GetGroup(AllOf(Get<Cell>(), Get<Empty>()));
		}

		public void Initialize()
		{
			foreach (var player in _players)
			foreach (var cell in _emptyCells)
			{
				var cellCoordinates = cell.GetCoordinates(withLayer: Default);
				var playerCoordinates = player.GetCoordinates();
				var path = _pathfinding.FindPath(playerCoordinates, cellCoordinates, allowDiagonals: false);

				var distanceToPlayer = path.Count;
				cell.Replace<DistanceToPlayer, int>(distanceToPlayer);
			}
		}
	}
}