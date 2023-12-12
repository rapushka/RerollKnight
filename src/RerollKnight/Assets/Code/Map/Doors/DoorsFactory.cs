using System;
using Code.Component;
using Entitas.Generic;
using UnityEngine;
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
			                    .Add<DoorTo, Entity<GameScope>>(roomEntity);

			var direction = _mapProvider.CurrentRoom.GetCoordinates() - roomEntity.GetCoordinates();

			var coordinates
				= direction == (1, 0)  ? new Coordinates(-1, center)           // top left
				: direction == (0, 1)  ? new Coordinates(center, -1)           // top right
				: direction == (0, -1) ? new Coordinates(lengthOfSide, center) // down left
				: direction == (-1, 0) ? new Coordinates(center, lengthOfSide) // down right
				                         : throw CantCreateDoorException(roomEntity);
			Debug.Log
				($"CurrentRoom: {_mapProvider.CurrentRoom} | roomEntity: {roomEntity} | coordinates: {coordinates}");

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