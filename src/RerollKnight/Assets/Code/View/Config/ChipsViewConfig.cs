using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class ChipsViewConfig
	{
		[field: SerializeField] public float MovingSpeed { get; private set; }

		[field: SerializeField] public float VerticalSpacing { get; private set; }

		[field: Header("Picking")]
		[field: SerializeField] public float DefaultOffset { get; private set; }

		[field: SerializeField] public float PickedOffset      { get; private set; }
		[field: SerializeField] public float UnavailableOffset { get; private set; }
		[field: SerializeField] public float InvisibleOffset   { get; private set; }

		[field: Header("Description")]
		[field: SerializeField] public Vector3 DescriptionOffset { get; private set; }

		[field: SerializeField] public float ShowDescriptionDelay { get; private set; } = 0.2f;
	}
}