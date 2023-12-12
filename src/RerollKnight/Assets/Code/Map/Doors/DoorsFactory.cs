using System;
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
		private readonly GenerationConfig _generationConfig;

		[Inject]
		public DoorsFactory
		(
			Contexts contexts,
			IResourcesService resources,
			IAssetsService assets,
			IHoldersProvider holdersProvider,
			MapProvider mapProvider,
			GenerationConfig generationConfig
		)
		{
			_resources = resources;
			_assets = assets;
			_holdersProvider = holdersProvider;
			_mapProvider = mapProvider;
			_generationConfig = generationConfig;
		}

		public Entity<GameScope> CreateDoor(Entity<GameScope> roomEntity)
		{
			var lengthOfSide = _generationConfig.RoomSizes.Column; // TODO: now will work only for square levels
			var center = lengthOfSide / 2;                         // TODO: and with odd length

			var entity = _assets.SpawnBehaviour(_resources.DoorPrefab, _holdersProvider.CellsHolder).Entity
			                    .Add<DoorTo, Entity<GameScope>>(roomEntity)
			                    .Is<AvailableToPick>(true);

			var direction = _mapProvider.CurrentRoom.GetCoordinates() - roomEntity.GetCoordinates();

			var coordinates
				= direction == (1, 0)  ? new Coordinates(-1, center)           // top left
				: direction == (0, 1)  ? new Coordinates(center, -1)           // top right
				: direction == (0, -1) ? new Coordinates(lengthOfSide, center) // down left
				: direction == (-1, 0) ? new Coordinates(center, lengthOfSide) // down right
				                         : throw CantCreateDoorException(roomEntity);

			entity.Add<Component.Coordinates, Coordinates>(coordinates.WithLayer(Coordinates.Layer.Bellow));

			return entity;
		}

		private InvalidOperationException CantCreateDoorException(Entity<GameScope> roomEntity)
			=> new($"The Room {roomEntity} isn't neighbor for the {_mapProvider.CurrentRoom}");
	}
}