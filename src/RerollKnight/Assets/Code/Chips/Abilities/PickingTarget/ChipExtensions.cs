using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;

namespace Code
{
	public static class ChipExtensions
	{
		public static HashSet<Entity<ChipsScope>> GetAbilities(this Entity<GameScope> chip)
			=> AbilityOfChip.Index.GetEntities(chip.Get<ChipId>().Value);
	}
}