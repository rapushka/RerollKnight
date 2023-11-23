using System;
using Entitas;
using Entitas.Generic;

namespace Code
{
	[Serializable] public class GameComponentID : ComponentID<GameScope> { }

	[Serializable] public class ChipsComponentID : ComponentID<ChipsScope> { }

	public static class ComponentIDExtensions
	{
		public static bool Is<TScope, TComponent>(this ComponentID<TScope> @this)
			where TScope : IScope
			where TComponent : IComponent, new()
		{
			return @this.Index == ComponentIndex<ChipsScope, TComponent>.Value;
		}
	}
}