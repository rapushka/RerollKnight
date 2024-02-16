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
		private readonly IAbilitiesFactory _abilitiesFactory;
		private readonly IHoldersProvider _holdersProvider;
		private readonly IViewConfig _viewConfig;
		private readonly IChipDescriptionBuilder _descriptionBuilder;

		[Inject]
		public ChipsFactory
		(
			Contexts contexts,
			IAssetsService assets,
			IResourcesService resources,
			IAbilitiesFactory abilitiesFactory,
			IHoldersProvider holdersProvider,
			IViewConfig viewConfig,
			IChipDescriptionBuilder descriptionBuilder
		)
		{
			_contexts = contexts;
			_holdersProvider = holdersProvider;
			_assets = assets;
			_resources = resources;
			_abilitiesFactory = abilitiesFactory;
			_viewConfig = viewConfig;
			_descriptionBuilder = descriptionBuilder;
		}

		public GameEntity Create(IChipConfig chipConfig, GameEntity actor, GameEntity face)
		{
			var entity = actor.Is<Player>() ? NewBehaviour() : NewEntity();
			return SetupChip(chipConfig, entity, face);
		}

		private GameEntity SetupChip(IChipConfig config, GameEntity entity, GameEntity face)
		{
			var chip = InitializeChip(entity)
			           .Add<Label, string>(config.LabelKey.GetLocalizedString())
			           .Add<ForeignID, string>(face.EnsureID())
				;

			if (config.CastAnimation != null)
				chip.Add<CastAnimation, AnimationClip>(config.CastAnimation);

			if (config.ItemPrefab != null)
				chip.Add<HoldingItem, GameObject>(config.ItemPrefab);

			if (config.Sound is not Sound.None)
				chip.Add<CastSound, Sound>(config.Sound);

			if (config.RepeatRate > 0)
				chip.Add<RepeatSound, float>(config.RepeatRate);

			foreach (var abilityConfig in config.Abilities)
				_abilitiesFactory.Create(abilityConfig, chip);

			chip.Add<Description, string>(_descriptionBuilder.Build(chip));

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
			          .Add<MovingSpeed, float>(_viewConfig.Chips.MovingSpeed);

		private GameEntity NewEntity() => _contexts.Get<GameScope>().CreateEntity();
	}
}