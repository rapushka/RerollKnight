namespace Code
{
	public class DoorsSpawner
	{
		private readonly MapProvider _mapProvider;
		private readonly DoorsFactory _doorsFactory;

		public DoorsSpawner(MapProvider mapProvider, DoorsFactory doorsFactory)
		{
			_mapProvider = mapProvider;
			_doorsFactory = doorsFactory;
		}

		public void Spawn()
		{
			foreach (var roomEntity in _mapProvider.NeighborsOfCurrentRoom)
				_doorsFactory.CreateDoor(roomEntity);
		}
	}
}