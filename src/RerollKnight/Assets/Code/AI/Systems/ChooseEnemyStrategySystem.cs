using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class ChooseEnemyStrategySystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly ChipKinds _chipKinds;

		public ChooseEnemyStrategySystem(Contexts contexts, ChipKinds chipKinds)
		{
			_contexts = contexts;
			_chipKinds = chipKinds;
		}

		private bool HasAnyAttackingChip => Chips.Any(_chipKinds.IsAttackingChip);

		private IEnumerable<Entity<GameScope>> Chips => CurrentActor.GetDependants().WhereHas<Chip>();

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			var strategy = Chips.Any()
				? HasAnyAttackingChip ? EnemyStrategy.Attack : EnemyStrategy.Defence
				: EnemyStrategy.EndTurn;

			CurrentActor.Replace<CurrentStrategy, EnemyStrategy>(strategy);
		}
	}
}