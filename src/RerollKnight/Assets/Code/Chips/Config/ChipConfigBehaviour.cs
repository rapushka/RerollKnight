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
	}

	public interface IRarityEntry
	{
		float Rarity { get; }
	}
}