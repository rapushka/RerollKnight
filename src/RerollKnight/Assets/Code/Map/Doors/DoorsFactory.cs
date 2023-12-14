using Code.Component;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class DoorsFactory
	{
		private readonly IResourcesService _resources;
		private readonly IAssetsService _assets;
		private readonly IHoldersProvider _holdersProvider;
		private readonly MapProvider _mapProvider;
		private readonly CoordinatesCalculator _coordinatesCalculator;

		[Inject]
		public DoorsFactory
		(
			Contexts contexts,
			IResourcesService resources,
			IAssetsService assets,
			IHoldersProvider holdersProvider,
			MapProvider mapProvider,
			CoordinatesCalculator coordinatesCalculator
		)
		{
			_resources = resources;
			_assets = assets;
			_holdersProvider = holdersProvider;
			_mapProvider = mapProvider;
			_coordinatesCalculator = coordinatesCalculator;
		}

		public Entity<GameScope> CreateEntrance(Entity<GameScope> roomEntity)
			=> GetDoor(roomEntity);

		public Entity<GameScope> CreateExit(Entity<GameScope> roomEntity)
			=> GetDoor(roomEntity)
				.Is<AvailableToPick>(true)
				.Is<AvailableToPick>(true);

		private Entity<GameScope> GetDoor(Entity<GameScope> roomEntity)
		{
			var transitionCoordinates = TransitionCoordinates(@for: roomEntity);

			return Component.Coordinates.Index.GetEntity(transitionCoordinates)
				?? NewDoor(roomEntity, transitionCoordinates);
		}

		private Entity<GameScope> NewDoor(Entity<GameScope> roomEntity, Coordinates transitionCoordinates)
			=> _assets.SpawnBehaviour(_resources.DoorPrefab, _holdersProvider.CellsHolder).Entity
			          .Add<Component.Coordinates, Coordinates>(transitionCoordinates)
			          .Add<DoorTo, Entity<GameScope>>(roomEntity);

		private Coordinates TransitionCoordinates(Entity<GameScope> @for)
			=> _coordinatesCalculator.TransitionBetweenRooms(_mapProvider.CurrentRoom, @for)
			                         .WithLayer(Coordinates.Layer.Bellow);
	}
}