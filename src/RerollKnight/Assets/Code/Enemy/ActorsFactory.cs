using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class ActorsFactory
	{
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly ChipsFactory _chipsFactory;

		[Inject]
		public ActorsFactory(IAssetsService assets, IResourcesService resources, ChipsFactory chipsFactory)
		{
			_assets = assets;
			_resources = resources;
			_chipsFactory = chipsFactory;
		}

		// TODO: chips shouldn't be null
		public void CreatePlayer(Coordinates coordinates, IEnumerable<ChipConfig> chips = null)
			=> Create(_resources.PlayerPrefab, coordinates, chips);

		public void CreateEnemy(Coordinates coordinates, IEnumerable<ChipConfig> chips = null)
			=> Create(_resources.EnemyPrefab, coordinates, chips);

		private void Create(EntityBehaviour<GameScope> prefab, Coordinates coordinates, IEnumerable<ChipConfig> chips)
		{
			var actor = SpawnPrefab(prefab)
			            .Replace<Component.Coordinates, Coordinates>(coordinates)
			            .Is<Actor>(true)
			            .Is<Target>(true)
			            .Identify()
				;

			CreateChips(chips, actor);
		}

		private void CreateChips(IEnumerable<ChipConfig> chips, Entity<GameScope> actor)
		{
			if (chips is null) // todo: remove when chips will be ensured
				return;

			foreach (var chip in chips.Select(CreateChip))
				chip.Add<BelongToActor, int>(actor.Get<ID>().Value);
		}

		private Entity<GameScope> CreateChip(ChipConfig chipConfig)
			=> _chipsFactory.Create(chipConfig);

		private Entity<GameScope> SpawnPrefab(EntityBehaviour<GameScope> prefab)
			=> _assets.SpawnBehaviour(prefab).Entity;
	}
}