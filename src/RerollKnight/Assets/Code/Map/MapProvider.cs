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
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<GameScope>> _rooms;
		private readonly IGroup<Entity<GameScope>> _currentRoom;

		public MapProvider(Contexts contexts)
		{
			_contexts = contexts;

			_rooms = contexts.GetGroup(Get<Room>());
			_currentRoom = contexts.GetGroup(AllOf(Get<Room>()).NoneOf(Get<Disabled>()));
		}

		public IEnumerable<Entity<GameScope>> NeighborsOfCurrentRoom
			=> CurrentRoom.GetCoordinates().Neighbors()
				.Select((n) => n.WithLayer(Coordinates.Layer.Room))
				.Where((c) => Index.HasEntity(c))
				.Select((c) => Index.GetEntity(c));
		private static PrimaryEntityIndex<GameScope, Component.Coordinates, Coordinates> Index
			=> Component.Coordinates.Index;

		public Entity<GameScope> CurrentRoom => _currentRoom.GetSingleEntity();
	}
}