using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class CellsFactory
	{
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly IHoldersProvider _holdersProvider;

		public CellsFactory(IAssetsService assets, IResourcesService resources, IHoldersProvider holdersProvider)
		{
			_assets = assets;
			_resources = resources;
			_holdersProvider = holdersProvider;
		}

		public Entity<GameScope>  Create(int x, int y, Coordinates.Layer layer = Coordinates.Layer.Bellow)
		{
			var coordinates = new Coordinates(x, y, layer);

			return _assets.SpawnBehaviour(_resources.CellPrefab, _holdersProvider.CellsHolder.transform).Entity
			              .Add<Component.Coordinates, Coordinates>(coordinates)
			              .Is<Empty>(true);
		}
	}
}