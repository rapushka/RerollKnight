using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace Code
{
	public class ChipConfigBehaviour : MonoBehaviour, IRarityEntry
	{
		[field: SerializeField] public LocalizedString LabelKey { get; private set; }

		[field: SerializeField] public int   Cost   { get; private set; }
		[field: SerializeField] public float Rarity { get; private set; }

		[field: SerializeField] public List<AbilityConfigBehaviour> Abilities { get; private set; }

		[field: Header("View")]
		[field: SerializeField] public AnimationClip CastAnimation { get; private set; }

		[field: SerializeField] public GameObject ItemPrefab { get; private set; }
		[field: SerializeField] public Sound      Sound      { get; private set; }
		[field: SerializeField] public float      RepeatRate { get; private set; } = -1f;
	}

	public interface IRarityEntry
	{
		float Rarity { get; }
	}
}