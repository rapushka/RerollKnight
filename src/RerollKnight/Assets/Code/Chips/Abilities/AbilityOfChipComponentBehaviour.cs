using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class AbilityOfChipComponentBehaviour : ComponentBehaviourBase<ChipsScope>
	{
		[SerializeField] private GameEntityBehaviour _behaviour;

		public override void Add(ref Entity<ChipsScope> entity)
			=> entity.Add<AbilityOfChip, Entity<GameScope>>(_behaviour.Entity);
	}
}