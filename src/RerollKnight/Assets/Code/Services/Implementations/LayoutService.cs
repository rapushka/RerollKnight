using UnityEngine;

namespace Code
{
	public interface ILayoutService
	{
		Vector3     OverFieldOffset { get; }
		Coordinates FieldSizes      { get; }

		Vector3 ChipsPositionStep     { get; }
		Vector3 PickedChipOffset      { get; }
		Vector3 UnavailableChipOffset { get; }
	}

	[CreateAssetMenu(fileName = "Layout", menuName = "Layout", order = 0)]
	public class LayoutService : ScriptableObject, ILayoutService
	{
		[field: SerializeField] public Vector3     OverFieldOffset { get; private set; }
		[field: SerializeField] public Coordinates FieldSizes      { get; private set; } = new(3, 3);

		[field: Header("Chips layout")]
		[field: SerializeField] public Vector3 ChipsPositionStep { get; private set; }

		[field: SerializeField] public Vector3 PickedChipOffset      { get; private set; }
		[field: SerializeField] public Vector3 UnavailableChipOffset { get; private set; }
	}
}