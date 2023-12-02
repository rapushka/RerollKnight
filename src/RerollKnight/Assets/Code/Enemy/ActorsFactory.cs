using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class ActorsFactory
	{
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;

		public ActorsFactory(IAssetsService assets, IResourcesService resources)
		{
			_assets = assets;
			_resources = resources;
		}

		public void CreatePlayer(Coordinates coordinates)
			=> Create(_resources.PlayerPrefab, coordinates);

		public void CreateEnemy(Coordinates coordinates)
			=> Create(_resources.EnemyPrefab, coordinates);

		private void Create(EntityBehaviour<GameScope> prefab, Coordinates coordinates)
		{
			SpawnPrefab(prefab)
				.Replace<Component.Coordinates, Coordinates>(coordinates)
				.Is<Actor>(true)
				.Is<Target>(true)
				.Identify()
				;
		}

		private Entity<GameScope> SpawnPrefab(EntityBehaviour<GameScope> prefab)
			=> _assets.SpawnBehaviour(prefab).Entity;
	}
}