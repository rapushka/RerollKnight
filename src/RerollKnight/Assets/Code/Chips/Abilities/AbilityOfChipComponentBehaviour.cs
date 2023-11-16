using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class AbilityOfChipComponentBehaviour : ComponentBehaviourBase<ChipsScope>
	{
		[SerializeField] private EntityBehaviour<GameScope> _behaviour;

		public override void Add(ref Entity<ChipsScope> entity)
			=> entity.Add<AbilityOfChip, int>(_behaviour.Entity.creationIndex);
	}
}