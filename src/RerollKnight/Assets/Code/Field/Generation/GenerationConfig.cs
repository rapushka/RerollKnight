using UnityEngine;
using static Code.Constants;

namespace Code
{
	[CreateAssetMenu(fileName = "Generation Config", menuName = ToolPath.Root + "Generation Config", order = 0)]
	public class GenerationConfig : ScriptableObject
	{
		[field: SerializeField] public RangeInt EnemiesCount { get; private set; }
	}
}