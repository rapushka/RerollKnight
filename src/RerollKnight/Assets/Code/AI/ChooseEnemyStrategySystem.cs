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

		private bool HasAnyAttackingChip
			=> CurrentActor.GetDependants().WhereHas<Chip>().Any(_chipKinds.IsAttackingChip);

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			var strategy = HasAnyAttackingChip ? EnemyStrategy.Attack : EnemyStrategy.Defence;
			CurrentActor.Replace<CurrentStrategy, EnemyStrategy>(strategy);
		}
	}
}