using Code.Component;
using Entitas.Generic;

namespace Code
{
	public sealed class CastDealDamageSystem : CastAbilitySystemBase<DealDamage>
	{
		public CastDealDamageSystem(Contexts contexts) : base(contexts) { }

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
			=> target.TakeDamage(ability.Get<DealDamage>().Value);
	}
}