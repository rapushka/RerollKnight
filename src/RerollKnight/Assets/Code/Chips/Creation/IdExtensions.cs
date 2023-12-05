using Code.Component;
using Entitas.Generic;

namespace Code
{
	public static class IdExtensions
	{
		public static Entity<TScope> Identify<TScope>(this Entity<TScope> @this)
			where TScope : IScope
			=> @this.Add<ID, string>($"{typeof(TScope).Name}_{@this.creationIndex}");

		public static bool IsBelongTo(this Entity<GameScope> @this, Entity<GameScope> other)
			=> @this.Get<ForeignID>().Value == other.Get<ID>().Value;
	}
}