using Code.Component;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class ChipsFactory
	{
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly AbilitiesFactory _abilitiesFactory;
		private IHoldersProvider _holdersProvider;

		[Inject]
		public ChipsFactory
		(
			IAssetsService assets,
			IResourcesService resources,
			AbilitiesFactory abilitiesFactory,
			IHoldersProvider holdersProvider
		)
		{
			_holdersProvider = holdersProvider;
			_assets = assets;
			_resources = resources;
			_abilitiesFactory = abilitiesFactory;
		}

		// todo: possibility to create chip without view
		public Entity<GameScope> Create(ChipConfig chipConfig)
		{
			var chip = SpawnChip(_holdersProvider.ChipsHolder.transform);
			chip.Add<Label, string>(chipConfig.Label);

			foreach (var abilityConfig in chipConfig.Abilities)
				_abilitiesFactory.Create(chip, abilityConfig);

			return chip;
		}

		private Entity<GameScope> SpawnChip(Transform parent = null)
			=> _assets.SpawnBehaviour(_resources.ChipPrefab, parent).Entity
			          .Identify();
	}
}