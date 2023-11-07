using Entitas.Generic;

namespace Code
{
	public static class ChipAbilityExtensions
	{
		public static bool IsOwnedBy(this Entity<ChipsScope> @this, Entity<GameScope> chip)
			=> @this.Get<AbilityOfChip>().Value == chip;
	}
}