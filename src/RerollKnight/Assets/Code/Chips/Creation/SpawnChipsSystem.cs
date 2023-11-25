using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using Range = Code.Component.Range;

namespace Code
{
	public sealed class SpawnChipsSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly ChipsConfig _chipsConfig;

		private GameObject _root;
		private int _counter;

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
			_root = new GameObject
			{
				name = "Cells Root",
				transform = { position = new Vector3(4.8f, 4.1f, 3.6f), },
			};

			foreach (var chipConfig in _chipsConfig.Chips)
				CreateChip(chipConfig);
		}

		private void CreateChip(ChipConfig chipConfig)
		{
			var chip = SpawnChip();
			chip.Replace<Position, Vector3>(Offset(chip));
			chip.Add<InitialPosition, Vector3>(chip.Get<Position>().Value);

			foreach (var abilityConfig in chipConfig.Abilities)
				SetupAbility(chip, abilityConfig);

			_counter++;
		}

		private Vector3 Offset(Entity<GameScope> chip)
			=> chip.Get<Position>().Value + new Vector3(_counter * 0.3f, 0, 0);

		private Entity<GameScope> SpawnChip()
			=> _assets.SpawnBehaviour(_resources.ChipPrefab, _root.transform).Entity
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