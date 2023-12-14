using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class CastKickSystem : CastAbilitySystemBase<Kick>
	{
		private readonly Contexts _contexts;

		public CastKickSystem(Contexts contexts, Query query) : base(contexts, query)
		{
			_contexts = contexts;
		}

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			Debug.Assert(ability.Has<Damage>());

			_contexts.Get<RequestScope>().CreateEntity()
			         .Add<ChangeHealth, int>(-ability.Get<Damage>().Value)
			         .Add<ForeignID, string>(target.Get<ID>().Value)
				;
		}
	}
}