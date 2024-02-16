using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class ChipsViewConfig
	{
		[field: SerializeField] public float MovingSpeed { get; private set; }

		[field: SerializeField] public float MaxHorizontalSpacing { get; private set; }

		[field: Header("Picking")]
		[field: SerializeField] public float DefaultPositionY { get; private set; }

		[field: SerializeField] public float PickedPositionY      { get; private set; }
		[field: SerializeField] public float UnavailablePositionY { get; private set; }
		[field: SerializeField] public float InvisiblePositionY   { get; private set; }

		[field: Header("Description")]
		[field: SerializeField] public Vector3 DescriptionOffset { get; private set; }

		[field: SerializeField] public float ShowDescriptionDelay { get; private set; } = 0.2f;
	}
}