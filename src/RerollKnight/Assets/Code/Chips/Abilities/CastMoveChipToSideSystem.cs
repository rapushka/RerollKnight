using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class CastMoveChipToSideSystem : CastAbilitySystemBase<MoveChipToSide>
	{
		private readonly UiMediator _uiMediator;

		public CastMoveChipToSideSystem(Contexts contexts, UiMediator uiMediator)
			: base(contexts)
			=> _uiMediator = uiMediator;

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			var chip = ability.GetOwner<ChipsScope, GameScope>();
			Debug.Assert(chip.Is<Chip>());

			_uiMediator.ShowAndGetWindow<MoveChipToSideWindow>().SetData(chip, target);
		}
	}
}