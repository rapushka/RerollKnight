using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
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

		private EntityBehaviour<GameScope> CellPrefab => _resources.CellPrefab;

		public void Initialize()
		{
			var root = new GameObject("Field Root");

			for (var x = 0; x < _layout.FieldSizes.Column; x++)
			for (var y = 0; y < _layout.FieldSizes.Row; y++)
			{
				var cellBehaviour = _assets.SpawnBehaviour(CellPrefab, root.transform);
				cellBehaviour.Entity.Add<CoordinatesUnderField, Coordinates>(new Coordinates(x, y));
			}
		}
	}
}