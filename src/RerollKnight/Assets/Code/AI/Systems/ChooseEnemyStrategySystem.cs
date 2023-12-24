using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class ChooseEnemyStrategySystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly ChipKinds _chipKinds;

		private readonly IGroup<Entity<GameScope>> _chips;

		public ChooseEnemyStrategySystem(Contexts contexts, ChipKinds chipKinds)
		{
			_contexts = contexts;
			_chipKinds = chipKinds;

			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<AvailableToPick>()));
		}

		private bool HasAnyAttackingChip => _chips.Any(_chipKinds.IsAttackingChip);

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			var strategy = _chips.Any()
				? HasAnyAttackingChip ? EnemyStrategy.Attack : EnemyStrategy.Defence
				: EnemyStrategy.EndTurn;

			Debug.Log($"strategy = {strategy}");
			CurrentActor.Replace<CurrentStrategy, EnemyStrategy>(strategy);
		}
	}
}