using Code.Component;
using Entitas.Generic;

namespace Code
{
	public static class DisplayNameExtensions
	{
		public static string GetDisplayName(this Entity<GameScope> @this)
			=> @this.Get<DisplayNameKey>().Value.GetLocalizedString();
	}
}