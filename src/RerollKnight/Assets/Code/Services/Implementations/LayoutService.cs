using UnityEngine;

namespace Code
{
	public interface ILayoutService
	{
		Vector3 OverFieldOffset { get; }

		Vector3 ChipsPositionStep     { get; }
		Vector3 PickedChipOffset      { get; }
		Vector3 UnavailableChipOffset { get; }
	}

	[CreateAssetMenu(fileName = "Layout", menuName = "Layout", order = 0)]
	public class LayoutService : ScriptableObject, ILayoutService
	{
		[field: SerializeField] public Vector3 OverFieldOffset { get; private set; }

		[field: Header("Chips layout")]
		[field: SerializeField] public Vector3 ChipsPositionStep { get; private set; }

		[field: SerializeField] public Vector3 PickedChipOffset      { get; private set; }
		[field: SerializeField] public Vector3 UnavailableChipOffset { get; private set; }
	}
}