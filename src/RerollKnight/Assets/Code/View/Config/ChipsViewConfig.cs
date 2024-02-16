using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class ChipsViewConfig
	{
		[field: SerializeField] public float DefaultChipPositionY     { get; private set; }
		[field: SerializeField] public float UnavailableChipPositionY { get; private set; }
		[field: SerializeField] public float InvisibleChipPositionY   { get; private set; }

		[field: Header("Chips layout")]
		[field: SerializeField] public float ChipsMovingSpeed { get; private set; }

		[field: SerializeField] public Vector3 ChipDescriptionOffset    { get; private set; }
		[field: SerializeField] public float   ShowChipDescriptionDelay { get; private set; } = 0.2f;

		[field: Header("Picking")]
		[field: SerializeField] public float PickedChipPositionY { get; private set; }

		[field: Header("Arrangement")]
		[field: SerializeField] public float MaxDistanceBetweenChips { get; private set; }
	}
}