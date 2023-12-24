using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class CastMoveChipToSideSystem : CastAbilitySystemBase<MoveChipToSide>
	{
		private readonly UiMediator _uiMediator;

		public CastMoveChipToSideSystem(Contexts contexts, UiMediator uiMediator)
			: base(contexts)
			=> _uiMediator = uiMediator;

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
			=> _uiMediator.ShowAndGetWindow<MoveChipToSideWindow>().SetData(target);
	}
}