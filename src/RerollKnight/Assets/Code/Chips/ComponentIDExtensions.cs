using Entitas;
using Entitas.Generic;

namespace Code
{
	public static class ComponentIDExtensions
	{
		public static bool Is<TComponent>(this ComponentID<GameScope> @this)
			where TComponent : IComponent, new()
			=> @this.Is<GameScope, TComponent>();

		public static bool Is<TComponent>(this ComponentID<ChipsScope> @this)
			where TComponent : IComponent, new()
			=> @this.Is<ChipsScope, TComponent>();

		public static bool Is<TScope, TComponent>(this ComponentID<TScope> @this)
			where TScope : IScope
			where TComponent : IComponent, new()
			=> @this.Index == ComponentIndex<TScope, TComponent>.Value;
	}
}