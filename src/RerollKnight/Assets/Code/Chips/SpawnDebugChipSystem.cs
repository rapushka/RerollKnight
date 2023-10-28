using Entitas;
using UnityEngine;

namespace Code
{
	public sealed class SpawnDebugChipSystem : IInitializeSystem
	{
		// ReSharper disable once NotAccessedField.Local - for consistent Adding
		private readonly Contexts _contexts;
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;

		public SpawnDebugChipSystem(Contexts contexts, IAssetsService assets, IResourcesService resources)
		{
			_contexts = contexts;
			_assets = assets;
			_resources = resources;
		}

		public void Initialize()
		{
			SpawnChip(at: new Vector3(1.9f, 3f, 3.9f));
			SpawnChip(at: new Vector3(2.9f, 3f, 2.9f));
		}

		private void SpawnChip(Vector3 at) => _assets.SpawnBehaviour(ChipPrefab, at);

		private GameEntityBehaviour ChipPrefab => _resources.ChipPrefab;
	}
}