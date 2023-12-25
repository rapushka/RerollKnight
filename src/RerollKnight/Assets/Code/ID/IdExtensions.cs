using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;

namespace Code
{
	public static class IdExtensions
	{
		public static string EnsureID<TScope>(this Entity<TScope> @this)
			where TScope : IScope
		{
			@this.Identify();
			return @this.Get<ID>().Value;
		}

		public static Entity<TScope> Identify<TScope>(this Entity<TScope> @this)
			where TScope : IScope
		{
			if (!@this.Has<ID>())
				@this.Add<ID, string>($"{typeof(TScope).Name}_{@this.creationIndex}");

			return @this;
		}

		public static bool IsBelongTo(this Entity<GameScope> @this, Entity<GameScope> other)
			=> @this.Get<ForeignID>().Value == other.Get<ID>().Value;

		public static Entity<GameScope> GetOwner(this Entity<GameScope> @this)
			=> @this.GetOwner<GameScope>();

		public static Entity<TScope> GetOwner<TScope>(this Entity<TScope> @this)
			where TScope : IScope
			=> ID.GetIndex<TScope>().GetEntity(@this.Get<ForeignID>().Value);

		public static Entity<TScopeOwner> GetOwner<TScopeOur, TScopeOwner>(this Entity<TScopeOur> @this)
			where TScopeOur : IScope
			where TScopeOwner : IScope
			=> ID.GetIndex<TScopeOwner>().GetEntity(@this.Get<ForeignID>().Value);

		public static HashSet<Entity<GameScope>> GetDependants(this Entity<GameScope> @this)
			=> @this.GetDependants<GameScope>();

		public static HashSet<Entity<TScope>> GetDependants<TScope>(this Entity<TScope> @this)
			where TScope : IScope
			=> ForeignID.GetIndex<TScope>().GetEntities(@this.Get<ID>().Value);

		public static HashSet<Entity<TScopeDependant>> GetDependants<TScopeDependant>(this Entity<GameScope> @this)
			where TScopeDependant : IScope
			=> @this.GetDependants<GameScope, TScopeDependant>();

		public static HashSet<Entity<TScopeDependant>> GetDependants<TScopeOur, TScopeDependant>
			(this Entity<TScopeOur> @this)
			where TScopeOur : IScope
			where TScopeDependant : IScope
			=> ForeignID.GetIndex<TScopeDependant>().GetEntities(@this.Get<ID>().Value);

		public static Entity<TScope> GetTarget<TScope>(this Entity<RequestScope> @this)
			where TScope : IScope
			=> ID.GetIndex<TScope>().GetEntity(@this.Get<ForeignID>().Value);
	}
}