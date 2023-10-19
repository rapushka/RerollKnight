using UnityEngine;

namespace Code
{
	public class AbilityOfChipComponentBehaviour : ChipsComponentBehaviourBase
	{
		[SerializeField] private GameEntityBehaviour _behaviour;

		public override void AddToEntity(ref ChipsEntity entity) => entity.AddAbilityOfChip(_behaviour.Entity);

		public override void RemoveFromEntity(ref ChipsEntity entity) => entity.RemoveAbilityOfChip();
	}
}