using Code.Component;
using Entitas.Generic;

namespace Code
{
	public static class PickingExtensions
	{
		public static void Pick(this Entity<GameScope> @this) => @this.SetPicking(true);

		public static void Unpick(this Entity<GameScope> @this) => @this.SetPicking(false);

		private static void SetPicking(this Entity<GameScope> @this, bool value)
		{
			if (@this.Is<Chip>())
				@this.Is<PickedChip>(value);
			else
				@this.Is<PickedTarget>(value);
		}
	}
}