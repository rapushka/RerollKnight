using Code.Component;
using Entitas.Generic;

namespace Code
{
	public static class SidesRollingExtensions
	{
		public static void PredefineRandomSide(this Entity<GameScope> actor)
		{
			var randomFace = actor.GetDependants().WhereHas<Face>().PickRandom();
			actor.Add<PredefinedNextSide, int>(randomFace.Get<Face>().Value);
		}
	}
}