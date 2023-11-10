using Entitas.Generic;

namespace Code
{
	public class ServicesMediator
	{
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;

		public ServicesMediator(IAssetsService assets, IResourcesService resources)
		{
			_assets = assets;
			_resources = resources;
		}

		public EntityBehaviour<GameScope> SpawnPlayer() => _assets.SpawnBehaviour(_resources.PlayerPrefab);
	}
}