using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class MapProvider
	{
		private readonly IGroup<Entity<GameScope>> _currentRoom;

		public MapProvider(Contexts contexts)
		{
			_currentRoom = contexts.GetGroup(AllOf(Get<Room>()).NoneOf(Get<Disabled>()));
		}

		public IEnumerable<Entity<GameScope>> NeighborsOfCurrentRoom
			=> CurrentRoom.GetCoordinates().Neighbors()
			              .Where((c) => Index.HasEntity(c))
			              .Select((c) => Index.GetEntity(c));

		public Entity<GameScope> CurrentRoom => _currentRoom.GetSingleEntity();

		private static PrimaryEntityIndex<GameScope, Component.Coordinates, Coordinates> Index
			=> Component.Coordinates.Index;
	}
}