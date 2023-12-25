using System.Collections.Generic;
using UnityEngine;
using static Code.Constants;

namespace Code
{
	[CreateAssetMenu(fileName = "Generation Config", menuName = ToolPath.Root + "Generation Config", order = 0)]
	public class GenerationConfig : ScriptableObject
	{
		[field: SerializeField] public RangeInt EnemiesCount { get; private set; }

		/// <summary> Measured in rooms </summary>
		[field: Tooltip("Measured in rooms\nThe layer doesn't matter")]
		[field: SerializeField] public Coordinates LevelSizes { get; private set; }

		/// <summary> Measured in cells </summary>
		[field: Tooltip("Measured in cells\nThe layer doesn't matter")]
		[field: SerializeField] public Coordinates RoomSizes { get; private set; }

		[field: SerializeField] public List<WallsLayout> WallLayouts { get; private set; }
	}
}