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

		public Entity<GameScope> CreateDoor(Entity<GameScope> roomEntity)
			=> _assets.SpawnBehaviour(_resources.DoorPrefab, _holdersProvider.CellsHolder).Entity
			          .Add<DoorTo, Entity<GameScope>>(roomEntity)
			          .Is<AvailableToPick>(true)
			          .Add<Component.Coordinates, Coordinates>(TransitionCoordinates(@for: roomEntity));

		private Coordinates TransitionCoordinates(Entity<GameScope> @for)
			=> _coordinatesCalculator.TransitionBetweenRooms(_mapProvider.CurrentRoom, @for)
			                         .WithLayer(Coordinates.Layer.Bellow);
	}
}