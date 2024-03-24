using System.Collections.Generic;
using System.Linq;

namespace Code
{
	public class ChipsSet
	{
		private readonly int _sideCount;
		private readonly bool _isForEnemy;
		private readonly ChipsConfig _chipsConfig;

		public List<List<ChipConfigBehaviour>> ChipsForFaces { get; } = new();

		private ChipsSet(int sideCount, bool isForEnemy, ChipsConfig chipsConfig)
		{
			_sideCount = sideCount;
			_isForEnemy = isForEnemy;
			_chipsConfig = chipsConfig;
		}

		public static ChipsSet FillForActor(int sideCount, bool isEnemy, ChipsConfig chipsConfig)
		{
			var chipsSet = new ChipsSet(sideCount, isEnemy, chipsConfig);
			chipsSet.Fill();

			return chipsSet;
		}

		private void Fill()
		{
			for (var i = 0; i < _sideCount; i++)
				ChipsForFaces.Add(FilterForActor().ToList());
		}

		private IEnumerable<ChipConfigBehaviour> FilterForActor()
			=> _isForEnemy ? FilterForEnemy() : FilterForPlayer();

		private IEnumerable<ChipConfigBehaviour> FilterForPlayer()
			=> CollectChipsForBudget(_chipsConfig.PlayerBudget, _chipsConfig.ChipsBehaviours);

		private IEnumerable<ChipConfigBehaviour> FilterForEnemy()
			=> CollectChipsForBudget(_chipsConfig.EnemyBudget, _chipsConfig.EnemyChips);

		private IEnumerable<ChipConfigBehaviour> CollectChipsForBudget
			(float currentBudget, IEnumerable<ChipConfigBehaviour> allChips)
		{
			var affordableChips = allChips.ToList();
			affordableChips.RemoveAll((c) => !IsAffordable(c, currentBudget));

			while (affordableChips.Any())
			{
				var randomChip = affordableChips.PickRandomWithRarity();
				yield return randomChip;

				currentBudget -= randomChip.Cost;
				affordableChips.RemoveAll((c) => !IsAffordable(c, currentBudget));
			}

			yield break;
			bool IsAffordable(IChipConfig c, float budget) => c.Cost <= budget;
		}
	}
}