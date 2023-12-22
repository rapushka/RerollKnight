using Code.Component;
using Entitas.Generic;

namespace Code
{
	public sealed class CastDealDamageSystem : CastAbilitySystemBase<DealDamage>
	{
		private readonly Contexts _contexts;

		public CastDealDamageSystem(Contexts contexts) : base(contexts)
		{
			_contexts = contexts;
		}

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			_contexts.Get<RequestScope>().CreateEntity()
			         .Add<ChangeHealth, int>(-ability.Get<DealDamage>().Value)
			         .Add<ForeignID, string>(target.Get<ID>().Value)
				;
		}
	}
}