using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public sealed class SpawnChipsSystem : IInitializeSystem
	{
		private readonly ChipsConfig _chipsConfig;
		private readonly ChipsFactory _chipsFactory;
		private readonly ILayoutService _layoutService;
		private readonly IHoldersProvider _holdersProvider;

		private int _counter;

		[Inject]
		public SpawnChipsSystem
		(
			ChipsConfig chipsConfig,
			ChipsFactory chipsFactory,
			ILayoutService layoutService,
			IHoldersProvider holdersProvider
		)
		{
			_chipsConfig = chipsConfig;
			_chipsFactory = chipsFactory;
			_layoutService = layoutService;
			_holdersProvider = holdersProvider;
		}

		public void Initialize()
		{
			foreach (var chip in _chipsConfig.Chips.Select(CreateChip))
			{
				chip.Replace<Position, Vector3>(_layoutService.ChipsPositionStep * _counter);
				chip.Add<InitialPosition, Vector3>(chip.Get<Position>().Value);
				_counter++;
			}
		}

		private Entity<GameScope> CreateChip(ChipConfig chipConfig)
			=> _chipsFactory.Create(chipConfig, _holdersProvider.ChipsHolder.transform);
	}
}