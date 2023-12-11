using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class SpawnFieldSystem : IInitializeSystem
	{
		private readonly IResourcesService _resources;
		private readonly IAssetsService _assets;
		private readonly IHoldersProvider _holdersProvider;
		private readonly GenerationConfig _generationConfig;

		[Inject]
		public SpawnFieldSystem
		(
			IResourcesService resources,
			IAssetsService assets,
			IHoldersProvider holdersProvider,
			GenerationConfig generationConfig
		)
		{
			_resources = resources;
			_assets = assets;
			_holdersProvider = holdersProvider;
			_generationConfig = generationConfig;
		}

		private EntityBehaviour<GameScope> CellPrefab => _resources.CellPrefab;

		public void Initialize()
		{
			var sizes = _generationConfig.RoomSizes;
			for (var x = 0; x < sizes.Column; x++)
			for (var y = 0; y < sizes.Row; y++)
			{
				_assets.SpawnBehaviour(CellPrefab, _holdersProvider.CellsHolder.transform).Entity
					.Add<Component.Coordinates, Coordinates>(new Coordinates(x, y, Coordinates.Layer.Bellow))
					.Is<Empty>(true)
					;
			}
		}
	}
}