using Code.Component;
using Entitas.Generic;

namespace Code
{
	public static class IdExtensions
	{
		public static Entity<TScope> IdentifyChip<TScope>(this Entity<TScope> @this)
			where TScope : IScope
			=> @this.Add<ChipId, int>(@this.creationIndex);
	}
}