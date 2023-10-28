using Entitas;
using Zenject;

namespace Code
{
	public sealed class SpawnFieldSystem : IInitializeSystem
	{
		private readonly IResourcesService _resources;
		private readonly IAssetsService _assets;
		private readonly ILayoutService _layout;

		[Inject]
		public SpawnFieldSystem(IResourcesService resources, IAssetsService assets, ILayoutService layout)
		{
			_assets = assets;
			_resources = resources;
			_layout = layout;
		}

		private GameEntityBehaviour CellPrefab => _resources.CellPrefab;

		public void Initialize()
		{
			for (var x = 0; x < _layout.FieldSizes.Column; x++)
			for (var y = 0; y < _layout.FieldSizes.Row; y++)
			{
				var cell = _assets.SpawnBehaviour(CellPrefab);
				cell.Entity.AddCoordinatesUnderField(new Coordinates(x, y));
			}
		}
	}
}