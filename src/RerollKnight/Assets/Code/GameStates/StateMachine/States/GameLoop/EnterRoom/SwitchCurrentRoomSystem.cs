using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class SwitchCurrentRoomSystem : IInitializeSystem
	{
		private readonly MapProvider _mapProvider;
		private readonly DoorsFactory _doorsFactory;
		private readonly Contexts _contexts;

		public SwitchCurrentRoomSystem(Contexts contexts, MapProvider mapProvider, DoorsFactory doorsFactory)
		{
			_contexts = contexts;
			_mapProvider = mapProvider;
			_doorsFactory = doorsFactory;
		}

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			var previousRoom = _mapProvider.CurrentRoom;

			previousRoom.Is<Disabled>(true);
			var nextRoom = _contexts.Get<GameScope>().Unique.GetEntity<NextRoom>();
			nextRoom.Is<Disabled>(false);
			nextRoom.Is<NextRoom>(false);

			// Flip Entrance
			var entrance = _doorsFactory.CreateEntrance(previousRoom);
			CurrentActor.ReplaceCoordinates(entrance.GetCoordinates(Coordinates.Layer.Default));
		}
	}
}