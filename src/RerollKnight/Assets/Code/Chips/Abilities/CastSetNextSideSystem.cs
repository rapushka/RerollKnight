using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class CastSetNextSideSystem : CastAbilitySystemBase<SetNextSide>
	{
		private readonly UiMediator _uiMediator;

		public CastSetNextSideSystem(Contexts contexts, UiMediator uiMediator) : base(contexts)
		{
			_uiMediator = uiMediator;
		}

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			_uiMediator.ShowAndGetWindow<PickSideWindow>();
		}
	}
}