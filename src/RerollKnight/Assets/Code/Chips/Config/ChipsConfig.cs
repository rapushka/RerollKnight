using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
	[CreateAssetMenu(fileName = "Chips", menuName = "RerollKnight/Chips", order = 0)]
	public class ChipsConfig : ScriptableObject
	{
		[field: SerializeField] public List<ChipConfigBehaviour> ChipsBehaviours { get; private set; }
		[field: SerializeField] public List<ChipConfigBehaviour> PlayerOnlyChips { get; private set; }

		[field: SerializeField] public float PlayerBudget { get; private set; }
		[field: SerializeField] public float EnemyBudget  { get; private set; }

		public IEnumerable<ChipConfigBehaviour> EnemyChips => ChipsBehaviours.Except(PlayerOnlyChips);
	}
}