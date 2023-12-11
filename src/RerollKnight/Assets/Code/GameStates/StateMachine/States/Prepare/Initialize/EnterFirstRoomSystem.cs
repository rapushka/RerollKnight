using Code.Component;
using Entitas;
using Zenject;

namespace Code
{
	public sealed class EnterFirstRoomSystem : IInitializeSystem
	{
		[Inject]
		public EnterFirstRoomSystem() { }

		public void Initialize()
		{
			var firstRoom = Component.Coordinates.Index.GetEntity(Coordinates.Zero.WithLayer(Coordinates.Layer.Room));
			firstRoom.Is<Disabled>(false);
		}
	}
}