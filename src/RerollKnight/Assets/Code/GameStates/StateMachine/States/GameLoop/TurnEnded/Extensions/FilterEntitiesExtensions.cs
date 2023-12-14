using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public static class FilterEntitiesExtensions
	{
		public static IEnumerable<Entity<GameScope>> WhereHas<TComponent>(this IEnumerable<Entity<GameScope>> @this)
			where TComponent : IComponent, new()
			=> @this.WhereHas<GameScope, TComponent>();

		public static IEnumerable<Entity<GameScope>> WhereHasNot<TComponent>(this IEnumerable<Entity<GameScope>> @this)
			where TComponent : IComponent, new()
			=> @this.WhereHasNot<GameScope, TComponent>();

		public static IEnumerable<Entity<TScope>> WhereHas<TScope, TComponent>(this IEnumerable<Entity<TScope>> @this)
			where TScope : IScope
			where TComponent : IComponent, new()
			=> @this.Where((e) => e.Has<TComponent>());

		public static IEnumerable<Entity<TScope>> WhereHasNot<TScope, TComponent>
			(this IEnumerable<Entity<TScope>> @this)
			where TScope : IScope
			where TComponent : IComponent, new()
			=> @this.Where((e) => !e.Has<TComponent>());
	}
}