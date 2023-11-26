using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class ChipsFactory
	{
		private readonly Contexts _contexts;
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;

		[Inject]
		public ChipsFactory(Contexts contexts, IAssetsService assets, IResourcesService resources)
		{
			_contexts = contexts;
			_assets = assets;
			_resources = resources;
		}

		public Entity<GameScope> Create(ChipConfig chipConfig, Transform parent = null)
		{
			var chip = SpawnChip(parent);

			foreach (var abilityConfig in chipConfig.Abilities)
				SetupAbility(chip, abilityConfig);

			return chip;
		}

		private Entity<GameScope> SpawnChip(Transform parent = null)
			=> _assets.SpawnBehaviour(_resources.ChipPrefab, parent).Entity
			          .IdentifyChip();

		private void SetupAbility(Entity<GameScope> chip, AbilityConfig config)
		{
			CreateAbility(@for: chip)
				.Is<Teleport>(config.Kind.Is<ChipsScope, Teleport>())
				.Is<SwitchPositions>(config.Kind.Is<ChipsScope, SwitchPositions>())
				.Add<MaxCountOfTargets, int>(config.TargetsCount)
				.Add<TargetConstraints, List<ComponentConstraint>>(config.TargetConstraints)
				.Add<Range, int>(config.Range, @if: config.Range > -1)
				;
		}

		private Entity<ChipsScope> CreateAbility(Entity<GameScope> @for)
			=> _contexts.Get<ChipsScope>().CreateEntity()
			            .Add<Component.AbilityState, AbilityState>(AbilityState.Inactive)
			            .Add<AbilityOfChip, int>(@for.Get<ChipId>().Value);
	}
}