using UnityEngine;
using static Code.Constants;

namespace Code
{
	[CreateAssetMenu(fileName = "Generation Config", menuName = ToolPath.Root + "Generation Config", order = 0)]
	public class GenerationConfig : ScriptableObject
	{
		[field: SerializeField] public RangeInt    EnemiesCount { get; private set; }
		[field: SerializeField] public RangeInt    WallsCount    { get; private set; }
		/// <summary> Measured in rooms </summary>
		[field: SerializeField] public Coordinates LevelSizes   { get; private set; }
	}
}