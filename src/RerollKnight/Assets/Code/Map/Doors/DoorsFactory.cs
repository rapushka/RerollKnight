using System;
using Code.Component;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class DoorsFactory
	{
		private readonly Contexts _contexts;
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
			_contexts = contexts;
			_resources = resources;
			_assets = assets;
			_holdersProvider = holdersProvider;
			_mapProvider = mapProvider;
			_generationConfig = generationConfig;
		}

		public Entity<GameScope> CreateDoor(Entity<GameScope> roomEntity)
		{
			var lenghtOfSide = _generationConfig.RoomSizes.Column; // TODO: now will work only for square levels
			var center = (lenghtOfSide / 2) + 1; // TODO: and with odd length

			var entity = _assets.SpawnBehaviour(_resources.DoorPrefab, _holdersProvider.CellsHolder).Entity
				.Add<DoorTo, Entity<GameScope>>(roomEntity);

			var direction = _mapProvider.CurrentRoom.GetCoordinates() - roomEntity.GetCoordinates();

			var coordinates
				= direction.Column == -1 ? new Coordinates(-1, center) // top left
				: direction.Column == 1  ? new Coordinates(center, -1) // top right
				: direction.Row == -1    ? new Coordinates(lenghtOfSide + 1, center) // down left
				: direction.Row == 1     ? new Coordinates(lenghtOfSide + 1, -1) // down right
				                           : throw CantCreateDoorException(roomEntity);

			entity.Add<Component.Coordinates, Coordinates>(coordinates.WithLayer(Coordinates.Layer.Bellow));

			return entity;
		}

		private static InvalidOperationException CantCreateDoorException(Entity<GameScope> roomEntity)
			=> new($"Can't create door for the room: {roomEntity}");
	}

	public enum Direction // TODO: needed??
	{
		TopLeft,
		TopRight,
		DownRight,
		DownLeft,
	}
}