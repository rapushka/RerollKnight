using System.Collections.Generic;
using System.Linq;

namespace Code
{
	public static class TargetsExtensions
	{
		public static IEnumerable<GameEntity> SelectTargets(this IEnumerable<ChipsEntity> @this)
			=> @this.SelectMany((e) => e.targets.Value);
	}
}