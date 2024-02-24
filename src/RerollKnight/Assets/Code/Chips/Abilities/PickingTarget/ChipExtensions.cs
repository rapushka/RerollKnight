using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;

namespace Code
{
	public static class ChipExtensions
	{
		public static HashSet<Entity<ChipsScope>> GetAbilities(this Entity<GameScope> chip)
			=> ForeignID.GetIndex<ChipsScope>().GetEntities(chip.Get<ID>().Value);

		public static bool IsFocused(this Entity<GameScope> chip)
			=> chip.Is<Hovered>();
	}
}