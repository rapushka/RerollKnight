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

		public SwitchCurrentRoomSystem(Contexts contexts, MapProvider mapProvider)
		{
			_mapProvider = mapProvider;
			contexts.GetGroup(Get<Room>());
			_doors = contexts.GetGroup(Get<DoorTo>());
		}

		private Entity<GameScope> Entrance => _doors.GetSingleEntity();

		public void Initialize()
		{
			_mapProvider.CurrentRoom.Is<Disabled>(true);
			var targetRoom = Entrance.Get<DoorTo>().Value;
			targetRoom.Is<Disabled>(false);
		}
	}
}