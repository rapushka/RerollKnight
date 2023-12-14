using Code.Component;
using Zenject;

namespace Code
{
	public class CellsSpawner
	{
		private readonly GenerationConfig _generationConfig;
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly IHoldersProvider _holdersProvider;

		[Inject]
		public CellsSpawner
		(
			GenerationConfig generationConfig,
			IAssetsService assets,
			IResourcesService resources,
			IHoldersProvider holdersProvider
		)
		{
			_generationConfig = generationConfig;
			_assets = assets;
			_resources = resources;
			_holdersProvider = holdersProvider;
		}

		public void SpawnCells()
		{
			var sizes = _generationConfig.RoomSizes;

			for (var x = 0; x < sizes.Column; x++)
			for (var y = 0; y < sizes.Row; y++)
			{
				SpawnCell(new Coordinates(x, y, Coordinates.Layer.Bellow));
			}
		}

		private void SpawnCell(Coordinates coordinates)
			=> _assets.SpawnBehaviour(_resources.CellPrefab, _holdersProvider.CellsHolder.transform).Entity
			          .Add<Component.Coordinates, Coordinates>(coordinates)
			          .Is<Empty>(true);
	}
}