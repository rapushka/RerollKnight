using Code.Component;
using Entitas.Generic;

namespace Code
{
	public static class IdExtensions
	{
		public static Entity<TScope> Identify<TScope>(this Entity<TScope> @this)
			where TScope : IScope
			=> @this.Add<ID, int>(@this.creationIndex);
	}
}