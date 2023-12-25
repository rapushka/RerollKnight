using UnityEngine;

namespace Code
{
	public interface IViewConfig
	{
		Vector3 OverFieldOffset { get; }

		float PickedChipPositionY      { get; }
		float DefaultChipPositionY     { get; }
		float UnavailableChipPositionY { get; }
		float MaxDistanceBetweenChips  { get; }
		float ChipsMovingSpeed         { get; }

		float EnemyThinkingDuration { get; }
		float RerollDuration        { get; }
		float RerollThrowHeight     { get; }
		float RoomTransferDuration  { get; }

		Vector3 ChipDescriptionOffset        { get; }
		float   RewardOffset                 { get; }
		Vector3 HealthChangeViewFlyDirection { get; }
		float   HealthChangeViewFlySpeed     { get; }
	}

	[CreateAssetMenu(fileName = "ViewConfig", menuName = "ViewConfig", order = 0)]
	public class ViewConfig : ScriptableObject, IViewConfig
	{
		[field: SerializeField] public Vector3 OverFieldOffset      { get; private set; }
		[field: SerializeField] public float   RoomTransferDuration { get; private set; }

		[field: Header("Chips layout")]
		[field: SerializeField] public float ChipsMovingSpeed { get; private set; }

		[field: SerializeField] public Vector3 ChipDescriptionOffset { get; private set; }

		[field: Header("Picking")]
		[field: SerializeField] public float PickedChipPositionY { get; private set; }

		[field: SerializeField] public float DefaultChipPositionY     { get; private set; }
		[field: SerializeField] public float UnavailableChipPositionY { get; private set; }

		[field: Header("Arrangement")]
		[field: SerializeField] public float MaxDistanceBetweenChips { get; private set; }

		[field: Header("AI")]
		[field: SerializeField] public float EnemyThinkingDuration { get; private set; }

		[field: Header("Reroll")]
		[field: SerializeField] public float RerollDuration { get; private set; }

		[field: SerializeField] public float RerollThrowHeight { get; private set; }

		[field: Header("Rewards")]
		[field: SerializeField] public float RewardOffset { get; private set; }

		[field: Header("Health Change View")]
		[field: SerializeField] public Vector3 HealthChangeViewFlyDirection { get; private set; }

		[field: SerializeField] public float HealthChangeViewFlySpeed { get; private set; }
	}
}