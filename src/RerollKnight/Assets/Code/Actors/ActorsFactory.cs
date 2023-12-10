using System.Collections.Generic;
using System.Linq;
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

		public GameEntity CreatePlayer(Coordinates coordinates, List<ChipConfigBehaviour> chips)
			=> Create(SpawnPrefab(_resources.PlayerPrefab), coordinates, chips);

		public GameEntity CreateEnemy(Coordinates coordinates, List<ChipConfigBehaviour> chips)
			=> Create(SpawnPrefab(_resources.EnemyPrefab), coordinates, chips)
				.Is<RoomResident>(true);

		private GameEntity Create(GameEntity entity, Coordinates coordinates, List<ChipConfigBehaviour> chips)
		{
			var actor = entity
			            .Replace<Component.Coordinates, Coordinates>(coordinates)
			            .Is<Actor>(true)
			            .Is<Target>(true)
			            .Identify()
				;
			actor.Add<Health, int>(actor.Get<MaxHealth>().Value);

			var faces = actor.GetDependants().Where((e) => e.Has<Face>());

			CreateChips(chips, actor, faces);

			_uiFactory.CreateHealthBar(actor);
			return actor;
		}

		private void CreateChips(List<ChipConfigBehaviour> chips, GameEntity actor, IEnumerable<GameEntity> faces)
		{
			foreach (var face in faces)
			foreach (var chipConfig in chips)
				_chipsFactory.Create(chipConfig, actor, face);
		}

		private GameEntity SpawnPrefab(EntityBehaviour<GameScope> prefab)
			=> _assets.SpawnBehaviour(prefab).Entity;
	}
}