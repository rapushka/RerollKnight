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
		private readonly ILayoutService _layout;
		private readonly IHoldersProvider _holdersProvider;

		[Inject]
		public SpawnFieldSystem
		(
			IResourcesService resources,
			IAssetsService assets,
			ILayoutService layout,
			IHoldersProvider holdersProvider
		)
		{
			_resources = resources;
			_assets = assets;
			_layout = layout;
			_holdersProvider = holdersProvider;
		}

		private EntityBehaviour<GameScope> CellPrefab => _resources.CellPrefab;

		public void Initialize()
		{
			for (var x = 0; x < _layout.FieldSizes.Column; x++)
			for (var y = 0; y < _layout.FieldSizes.Row; y++)
			{
				_assets.SpawnBehaviour(CellPrefab, _holdersProvider.CellsHolder.transform).Entity
					.Add<CoordinatesUnderField, Coordinates>(new Coordinates(x, y))
					.Is<Empty>(true)
					;
			}
		}
	}
}