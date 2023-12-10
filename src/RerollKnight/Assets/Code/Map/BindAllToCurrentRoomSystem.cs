using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class BindAllToCurrentRoomSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<GameScope>> _roomResidents;

		public BindAllToCurrentRoomSystem(Contexts contexts)
		{
			_contexts = contexts;
			_roomResidents = _contexts.GetGroup(AllOf(Get<ID>()).NoneOf(Get<ExistsBetweenRooms>(), Get<ForeignID>()));
		}

		public void Initialize()
		{
			var roomEntity = _contexts.Get<GameScope>().CreateEntity();
			// roomEntity.Add<Component.Coordinates, Coordinates>(new Coordinates(0, 0, Coordinates.Layer.Room));

			foreach (var e in _roomResidents)
				e.Add<ForeignID, string>(roomEntity.EnsureID());
		}
	}
}