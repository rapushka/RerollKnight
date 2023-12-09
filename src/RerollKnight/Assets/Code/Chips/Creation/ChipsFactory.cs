using Code.Component;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;
using Label = Code.Component.Label;
using Position = Code.Component.Position;

namespace Code
{
	public class ChipsFactory
	{
		private readonly Contexts _contexts;
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly AbilitiesFactory _abilitiesFactory;
		private readonly IHoldersProvider _holdersProvider;
		private readonly IViewConfig _viewConfig;

		[Inject]
		public ChipsFactory
		(
			Contexts contexts,
			IAssetsService assets,
			IResourcesService resources,
			AbilitiesFactory abilitiesFactory,
			IHoldersProvider holdersProvider,
			IViewConfig viewConfig
		)
		{
			_contexts = contexts;
			_holdersProvider = holdersProvider;
			_assets = assets;
			_resources = resources;
			_abilitiesFactory = abilitiesFactory;
			_viewConfig = viewConfig;
		}

		public GameEntity Create(ChipConfigBehaviour chipConfig, GameEntity actor, GameEntity face)
		{
			var entity = actor.Is<Player>() ? NewBehaviour() : NewEntity();
			return SetupChip(chipConfig, entity, face);
		}

		private GameEntity SetupChip(ChipConfigBehaviour config, GameEntity entity, GameEntity face)
		{
			var chip = InitializeChip(entity)
			           .Add<Label, string>(config.Label)
			           .Add<ForeignID, string>(face.EnsureID())
				;

			foreach (var abilityConfig in config.Abilities)
				_abilitiesFactory.Create(abilityConfig, chip);

			return chip;
		}

		private GameEntity InitializeChip(GameEntity entity)
			=> entity
			   .Is<Chip>(true)
			   .Add<DebugName, string>("chip")
			   .Identify();

		private GameEntity NewBehaviour()
			=> _assets.SpawnBehaviour(_resources.ChipPrefab, _holdersProvider.ChipsHolder.transform).Entity
			          .Is<Visible>(true)
			          .Add<Position, Vector3>(Vector3.zero)
			          .Add<MovingSpeed, float>(_viewConfig.ChipsMovingSpeed);

		private GameEntity NewEntity() => _contexts.Get<GameScope>().CreateEntity();
	}
}