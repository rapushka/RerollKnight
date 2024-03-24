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
		private readonly ChipsGenerator _chipsGenerator;
		private readonly IUiFactory _uiFactory;

		[Inject]
		public ActorsFactory
		(
			IAssetsService assets,
			IResourcesService resources,
			ChipsGenerator chipsGenerator,
			IUiFactory uiFactory
		)
		{
			_assets = assets;
			_resources = resources;
			_chipsGenerator = chipsGenerator;
			_uiFactory = uiFactory;
		}

		public GameEntity CreatePlayer(Coordinates coordinates)
			=> Create(SpawnPrefab(_resources.PlayerPrefab), coordinates);

		public GameEntity CreateEnemy(Coordinates coordinates)
			=> Create(SpawnPrefab(_resources.EnemyPrefab), coordinates)
				.Is<RoomResident>(true);

		private GameEntity Create(GameEntity entity, Coordinates coordinates)
		{
			var actor = entity
			            .Replace<Component.Coordinates, Coordinates>(coordinates)
			            .Is<Actor>(true)
			            .Is<Target>(true)
			            .Identify()
				;
			actor.Add<Health, int>(actor.Get<MaxHealth>().Value);

			_chipsGenerator.CreateChipsFor(actor);

			_uiFactory.CreateHealthBar(actor);
			return actor;
		}

		private GameEntity SpawnPrefab(EntityBehaviour<GameScope> prefab)
			=> _assets.SpawnBehaviour(prefab).Entity;
	}
}