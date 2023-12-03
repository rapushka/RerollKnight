using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;
using Zenject;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;

namespace Code
{
	public class ActorsFactory
	{
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly ChipsFactory _chipsFactory;
		private readonly UiFactory _uiFactory;

		[Inject]
		public ActorsFactory
		(
			IAssetsService assets,
			IResourcesService resources,
			ChipsFactory chipsFactory,
			UiFactory uiFactory
		)
		{
			_assets = assets;
			_resources = resources;
			_chipsFactory = chipsFactory;
			_uiFactory = uiFactory;
		}

		public GameEntity CreatePlayer(Coordinates coordinates, IEnumerable<ChipConfig> chips)
			=> Create(SpawnPrefab(_resources.PlayerPrefab), coordinates, chips);

		public GameEntity CreateEnemy(Coordinates coordinates, IEnumerable<ChipConfig> chips)
			=> Create(SpawnPrefab(_resources.EnemyPrefab), coordinates, chips);

		private GameEntity Create(GameEntity entity, Coordinates coordinates, IEnumerable<ChipConfig> chips)
		{
			var actor = entity
			            .Replace<Component.Coordinates, Coordinates>(coordinates)
			            .Is<Actor>(true)
			            .Is<Target>(true)
			            .Identify()
				;
			actor.Add<Health, int>(actor.Get<MaxHealth>().Value);

			CreateChips(chips, actor);
			_uiFactory.CreateHealthBar(actor);
			return actor;
		}

		private void CreateChips(IEnumerable<ChipConfig> chips, Entity<GameScope> actor)
		{
			foreach (var chipConfig in chips)
				_chipsFactory.Create(chipConfig, actor);
		}

		private Entity<GameScope> SpawnPrefab(EntityBehaviour<GameScope> prefab)
			=> _assets.SpawnBehaviour(prefab).Entity;
	}
}