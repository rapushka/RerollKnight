using System.Collections.Generic;
using UnityEngine;

namespace Code
{
	[CreateAssetMenu(fileName = "Chips", menuName = "RerollKnight/Chips", order = 0)]
	public class ChipsConfig : ScriptableObject
	{
		[field: SerializeField] public List<ChipConfig> Chips { get; private set; }
	}
}