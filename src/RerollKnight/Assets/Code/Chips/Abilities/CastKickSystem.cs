using Code.Component;
using Entitas.Generic;

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
			const int damage = 1; // TODO: take it out

			_contexts.Get<RequestScope>().CreateEntity()
			         .Add<ChangeHealth, int>(-damage)
			         .Add<ForeignID, string>(target.Get<ID>().Value)
				;
		}
	}
}