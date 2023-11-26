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

		private GameObject _root;
		private int _counter;

		[Inject]
		public SpawnChipsSystem(ChipsConfig chipsConfig, ChipsFactory chipsFactory)
		{
			_chipsConfig = chipsConfig;
			_chipsFactory = chipsFactory;
		}

		public void Initialize()
		{
			_root = new GameObject
			{
				name = "Cells Root",
				transform = { position = new Vector3(4.8f, 4.1f, 3.6f), },
			};

			foreach (var chip in _chipsConfig.Chips.Select(CreateChip))
			{
				chip.Replace<Position, Vector3>(Offset(chip));
				chip.Add<InitialPosition, Vector3>(chip.Get<Position>().Value);
				_counter++;
			}
		}

		private Entity<GameScope> CreateChip(ChipConfig chipConfig)
			=> _chipsFactory.Create(chipConfig, _root.transform);

		private Vector3 Offset(Entity<GameScope> chip)
			=> chip.Get<Position>().Value + new Vector3(_counter * 0.3f, 0, 0);
	}
}