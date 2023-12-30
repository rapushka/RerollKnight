using System;
using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class ChipsSet
	{
		private readonly Entity<GameScope> _actor;
		private readonly ChipsConfig _chipsConfig;

		public List<List<ChipConfigBehaviour>> ChipsForFaces { get; } = new();

		public ChipsSet(Entity<GameScope> actor, ChipsConfig chipsConfig)
		{
			_actor = actor;
			_chipsConfig = chipsConfig;

			Fill();
		}

		private void Fill()
		{
			var faces = _actor.GetDependants().Where((e) => e.Has<Face>());

			foreach (var _ in faces)
				ChipsForFaces.Add(FilterForActor(_actor).ToList());
		}

		private IEnumerable<ChipConfigBehaviour> FilterForActor(Entity<GameScope> actor)
			=> actor.Is<Player>()   ? FilterForPlayer()
				: actor.Is<Enemy>() ? FilterForEnemy()
				                      : throw new InvalidOperationException();

		private IEnumerable<ChipConfigBehaviour> FilterForPlayer()
			=> CollectChipsForBudget(_chipsConfig.PlayerBudget, _chipsConfig.ChipsBehaviours);

		private IEnumerable<ChipConfigBehaviour> FilterForEnemy()
			=> CollectChipsForBudget(_chipsConfig.EnemyBudget, _chipsConfig.EnemyChips);

		private IEnumerable<ChipConfigBehaviour> CollectChipsForBudget
			(float currentBudget, IEnumerable<ChipConfigBehaviour> allChips)
		{
			int counter = 1_000; // TODO: remove:(

			var allChipsArray = allChips as ChipConfigBehaviour[] ?? allChips.ToArray();
			while (currentBudget > 0)
			{
				var affordableChips = allChipsArray.Where((c) => c.Cost <= currentBudget).ToArray();

				if (!affordableChips.Any())
					yield break;

				var randomChip = affordableChips.PickRandomWithRarity();

				yield return randomChip;
				currentBudget -= randomChip.Cost;

				if (counter-- <= 0)
				{
					Debug.LogError("prevent endless loop");
					yield break;
				}
			}
		}
	}
}