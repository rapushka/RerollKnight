using Code.Component;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class RewardFactory
	{
		private readonly MapProvider _mapProvider;
		private readonly CoordinatesCalculator _coordinatesCalculator;
		private readonly IViewConfig _viewConfig;
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly ChipsConfig _chipsConfig;

		[Inject]
		public RewardFactory
		(
			IAssetsService assets,
			IResourcesService resources,
			MapProvider mapProvider,
			CoordinatesCalculator coordinatesCalculator,
			IViewConfig viewConfig,
			ChipsConfig chipsConfig
		)
		{
			_mapProvider = mapProvider;
			_coordinatesCalculator = coordinatesCalculator;
			_viewConfig = viewConfig;
			_chipsConfig = chipsConfig;
			_assets = assets;
			_resources = resources;
		}

		private ChipConfigBehaviour RandomChipConfig => _chipsConfig.ChipsBehaviours.ToArray().PickRandom();

		// ReSharper disable once UnusedMember.Local - TODO
		private Vector3 RewardPosition => _coordinatesCalculator.RoomCenter.ToTopDown()
		                                                        .Add(y: _viewConfig.RewardOffset);

		public Entity<GameScope> Create()
		{
			var currentRoom = _mapProvider.CurrentRoom;
			return Spawn(currentRoom);
		}

		private Entity<GameScope> Spawn(Entity<GameScope> currentRoom)
		{
			var config = RandomChipConfig;

			return _assets.SpawnBehaviour(_resources.RewardPrefab).Entity
			              .Identify()
			              .Is<Reward>(true)
			              .Is<RoomResident>(true)
			              .Add<ForeignID, string>(currentRoom.EnsureID())
			              .Add<ChipConfig, ChipConfigBehaviour>(config)
			              .Replace<Position, Vector3>(new Vector3(2f, 1f, 2f))
			              .Is<AvailableToPick>(true)
			              .Add<Label, string>(config.LabelKey.GetLocalizedString());
		}
	}
}