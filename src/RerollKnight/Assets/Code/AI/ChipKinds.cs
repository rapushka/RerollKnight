using System.Linq;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class ChipKinds
	{
		private readonly ChipsConfig _chipsConfig;

		[Inject]
		public ChipKinds(ChipsConfig chipsConfig)
			=> _chipsConfig = chipsConfig;

		private int[] AttackIndexes   => _chipsConfig.AttackingAbilities.Select((cid) => cid.Index).ToArray();
		private int[] MovementIndexes => _chipsConfig.MovementAbilities.Select((cid) => cid.Index).ToArray();

		public bool IsAttackingChip(Entity<GameScope> chip)
			=> chip.GetDependants<GameScope, ChipsScope>().Any(IsAttackingAbility);

		public bool IsMovementChip(Entity<GameScope> chip)
			=> chip.GetDependants<GameScope, ChipsScope>().Any(IsMovementAbility);

		private bool IsAttackingAbility(Entity<ChipsScope> ability)
			=> ability.HasAnyComponent(AttackIndexes);

		private bool IsMovementAbility(Entity<ChipsScope> ability)
			=> ability.HasAnyComponent(MovementIndexes);
	}
}