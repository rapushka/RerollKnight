using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;

namespace Code
{
	public interface ITransport
	{
		void Transfer();
	}

	public abstract class GameTransportBase : ComponentBehaviourBase<GameScope>, ITransport
	{
		protected Entity<GameScope> Entity;

		public override void Add(ref Entity<GameScope> entity)
		{
			Entity = entity;
			entity.AddToList<GameScope, Transport, ITransport>(this);
		}

		public abstract void Transfer();
	}

	public static class ListComponentsExtensions
	{
		public static Entity<TScope> AddToList<TScope, TComponent, TValue>(this Entity<TScope> @this, TValue value)
			where TScope : IScope
			where TComponent : ValueComponent<List<TValue>>, new()
		{
			var list = @this.GetOrDefault<TComponent>()?.Value
			           ?? new List<TValue>();

			list.Add(value);
			@this.ReplaceList<TScope, TComponent, TValue>(list);

			return @this;
		}

		public static Entity<TScope> ReplaceList<TScope, TComponent, TValue>
			(this Entity<TScope> @this, List<TValue> list)
			where TScope : IScope
			where TComponent : ValueComponent<List<TValue>>, new()
		{
			var index = ComponentIndex<TScope, TComponent>.Value;
			var component = @this.CreateComponent<TComponent>(index);
			component.Value = list;
			@this.ReplaceComponent(index, component);

			return @this;
		}
	}
}