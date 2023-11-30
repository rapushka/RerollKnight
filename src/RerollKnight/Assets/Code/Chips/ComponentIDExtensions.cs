using Entitas;
using Entitas.Generic;

namespace Code
{
	public static class ComponentIDExtensions
	{
		public static bool Is<TScope, TComponent>(this ComponentID<TScope> @this)
			where TScope : IScope
			where TComponent : IComponent, new()
			=> @this.Index == ComponentIndex<ChipsScope, TComponent>.Value;
	}
}