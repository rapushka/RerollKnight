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

		public Entity<GameScope> Create(ChipConfigBehaviour chipConfig, Entity<GameScope> actor)
		{
			var entity = actor.Is<Player>() ? NewBehaviour() : NewEntity();
			return SetupChip(chipConfig, entity, actor);
		}

		private Entity<GameScope> SetupChip
		(
			ChipConfigBehaviour config,
			Entity<GameScope> entity,
			Entity<GameScope> actor
		)
		{
			var chip = InitializeChip(entity)
					.Add<Label, string>(config.Label)
					.Add<ForeignID, string>(actor.Get<ID>().Value)
				;

			foreach (var abilityConfig in config.Abilities)
				_abilitiesFactory.Create(abilityConfig, chip);

			return chip;
		}

		private Entity<GameScope> InitializeChip(Entity<GameScope> entity)
			=> entity
			   .Is<Chip>(true)
			   .Add<DebugName, string>("chip")
			   .Identify();

		private Entity<GameScope> NewBehaviour()
			=> _assets.SpawnBehaviour(_resources.ChipPrefab, _holdersProvider.ChipsHolder.transform).Entity;

		private Entity<GameScope> NewEntity() => _contexts.Get<GameScope>().CreateEntity();
	}
}