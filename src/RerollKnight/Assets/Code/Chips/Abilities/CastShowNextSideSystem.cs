using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class CastShowNextSideSystem : CastAbilitySystemBase<ShowNextSide>
	{
		public CastShowNextSideSystem(Contexts contexts) : base(contexts) { }

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
			=> target.PredefineRandomSide();
	}
}