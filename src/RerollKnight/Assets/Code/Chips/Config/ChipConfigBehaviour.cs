using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace Code
{
	public interface IChipConfig
	{
		LocalizedString              LabelKey      { get; }
		int                          Cost          { get; }
		float                        Rarity        { get; }
		List<AbilityConfigBehaviour> Abilities     { get; }
		AnimationClip                CastAnimation { get; }
		GameObject                   ItemPrefab    { get; }
		Sound                        Sound         { get; }
		float                        RepeatRate    { get; }
	}

	public class ChipConfigBehaviour : MonoBehaviour, IRarityEntry, IChipConfig
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
		public float Rarity { get; }
	}
}