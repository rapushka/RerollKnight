using System;
using System.Collections.Generic;
using System.Linq;
using Code.Component;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;

namespace Code
{
	public class ChipsGenerator
	{
		private readonly ChipsConfig _chipsConfig;
		private readonly ChipsFactory _chipsFactory;

		public ChipsGenerator(ChipsConfig chipsConfig, ChipsFactory chipsFactory)
		{
			_chipsConfig = chipsConfig;
			_chipsFactory = chipsFactory;
		}

		private IEnumerable<ChipConfigBehaviour> AllChips => _chipsConfig.ChipsBehaviours;

		public void CreateChipsFor(GameEntity actor, GameEntity face)
		{
			foreach (var chipConfig in FilterForActor(actor))
				_chipsFactory.Create(chipConfig, actor, face);
		}

		private IEnumerable<ChipConfigBehaviour> FilterForActor(GameEntity actor)
			=> actor.Is<Player>()   ? FilterForPlayer()
				: actor.Is<Enemy>() ? FilterForEnemy()
				                      : throw new InvalidOperationException();

		private IEnumerable<ChipConfigBehaviour> FilterForPlayer()
			=> CollectChipsForBudget(_chipsConfig.PlayerBudget);

		private IEnumerable<ChipConfigBehaviour> FilterForEnemy()
			=> CollectChipsForBudget(_chipsConfig.EnemyBudget);

		private IEnumerable<ChipConfigBehaviour> CollectChipsForBudget(float currentBudget)
		{
			while (currentBudget > 0)
			{
				var affordableChips = AllChips.Where((c) => c.Cost <= currentBudget).ToArray();

				if (!affordableChips.Any())
					yield break;

				var randomChip = affordableChips.PickRandom();

				yield return randomChip;
				currentBudget -= randomChip.Cost;
			}
		}
	}
}