using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class SwitchCurrentRoomSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<GameScope>> _doors;
		private readonly MapProvider _mapProvider;
		private readonly DoorsFactory _doorsFactory;
		private Contexts _contexts;

		public SwitchCurrentRoomSystem(Contexts contexts, MapProvider mapProvider, DoorsFactory doorsFactory)
		{
			_contexts = contexts;
			_mapProvider = mapProvider;
			_doors = contexts.GetGroup(Get<DoorTo>());
			_doorsFactory = doorsFactory;
		}

		private Entity<GameScope> ExitFromPrevRoom => _doors.GetSingleEntity();

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			var exitFromPrevRoom = ExitFromPrevRoom;
			var previousRoom = _mapProvider.CurrentRoom;

			previousRoom.Is<Disabled>(true);
			var targetRoom = exitFromPrevRoom.Get<DoorTo>().Value;
			targetRoom.Is<Disabled>(false);

			// Flip Entrance
			var entrance = _doorsFactory.CreateEntrance(previousRoom);
			CurrentActor.ReplaceCoordinates(entrance.GetCoordinates(Coordinates.Layer.Default));
			exitFromPrevRoom.Is<Destroyed>(true);
		}
	}
}