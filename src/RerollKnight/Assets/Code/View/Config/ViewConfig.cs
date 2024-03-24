using UnityEngine;

namespace Code
{
	public interface IViewConfig
	{
		Vector3 OverFieldOffset { get; }

		ChipsViewConfig Chips { get; }

		float EnemyThinkingDuration { get; }
		float RerollDuration        { get; }
		float RerollThrowHeight     { get; }
		float RoomTransferDuration  { get; }

		float   RewardOffset                 { get; }
		Vector3 HealthChangeViewFlyDirection { get; }
		float   HealthChangeViewFlySpeed     { get; }

		float DiceWalkingSpeed { get; }
	}

	[CreateAssetMenu(fileName = "ViewConfig", menuName = "ViewConfig", order = 0)]
	public class ViewConfig : ScriptableObject, IViewConfig
	{
		[field: SerializeField] public ChipsViewConfig Chips { get; private set; }

		[field: SerializeField] public Vector3 OverFieldOffset      { get; private set; }
		[field: SerializeField] public float   RoomTransferDuration { get; private set; }

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

		[field: Header("Animations")]
		[field: SerializeField] public float DiceWalkingSpeed { get; private set; }
	}
}