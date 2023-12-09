using UnityEngine;

namespace Code
{
	public interface ILayoutService
	{
		Vector3 OverFieldOffset { get; }

		Vector3 ChipsPositionStep        { get; }
		float   PickedChipPositionY      { get; }
		float   DefaultChipPositionY     { get; }
		float   UnavailableChipPositionY { get; }
		float   ChipsPanelWidth          { get; }
	}

	[CreateAssetMenu(fileName = "Layout", menuName = "Layout", order = 0)]
	public class LayoutService : ScriptableObject, ILayoutService
	{
		[field: SerializeField] public Vector3 OverFieldOffset { get; private set; }

		[field: Header("Chips layout")]
		[field: SerializeField] public Vector3 ChipsPositionStep { get; private set; }

		[field: SerializeField] public float PickedChipPositionY      { get; private set; }
		[field: SerializeField] public float DefaultChipPositionY     { get; private set; }
		[field: SerializeField] public float UnavailableChipPositionY { get; private set; }
		[field: SerializeField] public float ChipsPanelWidth          { get; private set; }
	}
}