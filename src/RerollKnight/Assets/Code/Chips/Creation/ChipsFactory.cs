using Code.Component;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class ChipsFactory
	{
		private readonly Contexts _contexts;
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly AbilitiesFactory _abilitiesFactory;
		private readonly IHoldersProvider _holdersProvider;

		[Inject]
		public ChipsFactory
		(
			Contexts contexts,
			IAssetsService assets,
			IResourcesService resources,
			AbilitiesFactory abilitiesFactory,
			IHoldersProvider holdersProvider
		)
		{
			_contexts = contexts;
			_holdersProvider = holdersProvider;
			_assets = assets;
			_resources = resources;
			_abilitiesFactory = abilitiesFactory;
		}

		public Entity<GameScope> Create(ChipConfig chipConfig, bool withView)
			=> withView ? CreateWithView(chipConfig) : Create(chipConfig);

		public Entity<GameScope> CreateWithView(ChipConfig chipConfig)
			=> SetupChip(chipConfig, NewBehaviour());

		public Entity<GameScope> Create(ChipConfig chipConfig)
			=> SetupChip(chipConfig, NewEntity());

		private Entity<GameScope> SetupChip(ChipConfig chipConfig, Entity<GameScope> entity)
		{
			var chip = InitializeChip(entity, chipConfig.Label);

			foreach (var abilityConfig in chipConfig.Abilities)
				_abilitiesFactory.Create(chip, abilityConfig);

			return chip;
		}

		private Entity<GameScope> InitializeChip(Entity<GameScope> entity, string label)
			=> entity
			   .Is<Chip>(true)
			   .Add<DebugName, string>("chip")
			   .Add<Label, string>(label)
			   .Identify();

		private Entity<GameScope> NewBehaviour()
			=> _assets.SpawnBehaviour(_resources.ChipPrefab, _holdersProvider.ChipsHolder.transform).Entity;

		private Entity<GameScope> NewEntity() => _contexts.Get<GameScope>().CreateEntity();
	}
}