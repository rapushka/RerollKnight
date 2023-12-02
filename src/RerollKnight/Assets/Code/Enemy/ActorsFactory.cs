using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class ActorsFactory
	{
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly ChipsFactory _chipsFactory;
		private readonly ILayoutService _layoutService;
		private readonly IHoldersProvider _holdersProvider;

		private int _counter;

		[Inject]
		public ActorsFactory
		(
			IAssetsService assets,
			IResourcesService resources,
			ChipsFactory chipsFactory,
			ILayoutService layoutService,    // todo: remove these kakuli
			IHoldersProvider holdersProvider // todo: remove these kakuli
		)
		{
			_assets = assets;
			_resources = resources;
			_chipsFactory = chipsFactory;
			_layoutService = layoutService;
			_holdersProvider = holdersProvider;
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
			if (chips is null)
				return;

			foreach (var chip in chips.Select(CreateChip))
			{
				chip.Replace<Position, Vector3>(_layoutService.ChipsPositionStep * _counter);
				chip.Add<InitialPosition, Vector3>(chip.Get<Position>().Value);

				chip.Add<BelongToActor, int>(actor.Get<ID>().Value); // there must stay only this

				_counter++;
			}

			_counter = 0;
		}

		private Entity<GameScope> CreateChip(ChipConfig chipConfig)
			=> _chipsFactory.Create(chipConfig, _holdersProvider.ChipsHolder.transform);

		private Entity<GameScope> SpawnPrefab(EntityBehaviour<GameScope> prefab)
			=> _assets.SpawnBehaviour(prefab).Entity;
	}
}