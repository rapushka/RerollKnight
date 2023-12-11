using Code.Component;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class RoomFactory
	{
		private readonly Contexts _contexts;

		[Inject]
		public RoomFactory(Contexts contexts)
			=> _contexts = contexts;

		public Entity<GameScope> Create(Coordinates coordinates)
			=> _contexts.Get<GameScope>().CreateEntity()
			            .Identify()
			            .Add<DebugName, string>("Room")
			            .Add<Component.Coordinates, Coordinates>(coordinates);
	}
}