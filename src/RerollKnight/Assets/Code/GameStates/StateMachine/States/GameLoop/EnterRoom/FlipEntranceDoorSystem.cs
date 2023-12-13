using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class FlipEntranceDoorSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private DoorsFactory _doorsFactory;

		public FlipEntranceDoorSystem(Contexts contexts, MapProvider mapProvider, DoorsFactory doorsFactory)
		{
			_doorsFactory = doorsFactory;
			_contexts = contexts;
		}

		public void Initialize()
		{
			
			
			// _mapProvider.CurrentRoom.Is<Disabled>(true);
		}
	}
}