using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public sealed class SpawnChipsSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private ChipsConfig _chipsConfig;

		private GameObject _root;

		[Inject]
		public SpawnChipsSystem
		(
			Contexts contexts,
			IAssetsService assets,
			IResourcesService resources,
			ChipsConfig chipsConfig
		)
		{
			_chipsConfig = chipsConfig;
			_contexts = contexts;
			_assets = assets;
			_resources = resources;
		}

		public void Initialize()
		{
			_root = new GameObject("Cells Root");

			foreach (var chipConfig in _chipsConfig.Chips)
				CreateChip(chipConfig);
		}

		private void CreateChip(ChipConfig chipConfig)
		{
			var chip = SpawnChip();

			foreach (var abilityConfig in chipConfig.Abilities)
				SetupAbility(chip, abilityConfig);
		}

		private Entity<GameScope> SpawnChip()
			=> _assets.SpawnBehaviour(_resources.ChipPrefab, _root.transform).Entity
			          .IdentifyChip();

		private void SetupAbility(Entity<GameScope> chip, AbilityConfig config)
		{
			CreateAbility(chip)
				.Is<Teleport>(config.Kind.Is<ChipsScope, Teleport>())
				.Is<SwitchPositions>(config.Kind.Is<ChipsScope, SwitchPositions>())
				.Add<Range, int>(config.Range)
				.Add<MaxCountOfTargets, int>(config.TargetsCount)
				.Add<TargetConstraints, List<ComponentConstraint>>(config.TargetConstraints);
		}

		private Entity<ChipsScope> CreateAbility(Entity<GameScope> chip)
			=> _contexts.Get<ChipsScope>().CreateEntity()
			            .Add<Component.AbilityState, AbilityState>(AbilityState.Inactive)
			            .Add<AbilityOfChip, int>(chip.Get<ChipId>().Value);
	}
}