using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public sealed class SpawnPlayerChipsSystem : IInitializeSystem
	{
		private readonly ChipsConfig _chipsConfig;
		private readonly ChipsFactory _chipsFactory;
		private readonly ILayoutService _layoutService;
		private readonly IHoldersProvider _holdersProvider;
		private readonly IGroup<Entity<GameScope>> _players;

		private int _counter;

		[Inject]
		public SpawnPlayerChipsSystem
		(
			Contexts contexts,
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

			_players = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Player>());
		}

		public void Initialize()
		{
			foreach (var player in _players)
			foreach (var chip in _chipsConfig.Chips.Select(CreateChip))
			{
				chip.Replace<Position, Vector3>(_layoutService.ChipsPositionStep * _counter);
				chip.Add<InitialPosition, Vector3>(chip.Get<Position>().Value);
				chip.Add<BelongToActor, int>(player.Get<ID>().Value);

				_counter++;
			}
		}

		private Entity<GameScope> CreateChip(ChipConfig chipConfig)
			=> _chipsFactory.Create(chipConfig, _holdersProvider.ChipsHolder.transform);
	}
}